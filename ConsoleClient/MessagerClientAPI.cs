﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClientMessager
{
    internal class MessagerClientAPI
    {
        public void TestJson() {
            Message msg = new Message("AAA", "Hi", DateTime.UtcNow);
            string output = JsonConvert.SerializeObject(msg);
            Console.WriteLine(output);
            Message deserializemsg = JsonConvert.DeserializeObject<Message>(output);
            Console.WriteLine(deserializemsg);

        }
        public Message GetMessage(int MessageId)
        {
            WebRequest request = WebRequest.Create("http://localhost:5000/api/Messager/" + MessageId.ToString());
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            string status = ((HttpWebResponse)response).StatusDescription;
            Stream data = response.GetResponseStream();
            StreamReader reader = new StreamReader(data);
            string json = reader.ReadToEnd();
            reader.Close();
            data.Close();
            response.Close();
            if ((status.ToLower() == "ok") && (json != "Not found")) {
                Message deserializemsg = JsonConvert.DeserializeObject<Message>(json);
                return deserializemsg;
            }
            return null;
        }
        public bool SendMessage(Message msg)
        {
            WebRequest request = WebRequest.Create("http://localhost:5000/api/Messager");
            request.Method = "POST";
            string postData = JsonConvert.SerializeObject(msg);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream data = request.GetRequestStream();
            data.Write(byteArray, 0, byteArray.Length); 
            data.Close();
            WebResponse response = request.GetResponse();
            data = response.GetResponseStream();
            StreamReader reader = new StreamReader(data);
            string json = reader.ReadToEnd();
            reader.Close();
            response.Close();
            data.Close();

            return true;
        }
    }
}
