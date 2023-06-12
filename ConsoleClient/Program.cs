using System;
using Newtonsoft.Json;
namespace ConsoleClientMessager
{
    class Program
    {
        private static int MessageId;
        private static string UserName;
        private static MessagerClientAPI API = new MessagerClientAPI();

        private static void GetNewMessage()
        {
            Message msg = API.GetMessage(MessageId);
            while (msg != null)
            {
                Console.WriteLine(msg);
                MessageId++;
                msg = API.GetMessage(MessageId);
            }
        }
    static void Main(string[] args)
        {
            /// Message msg = new Message("AAA", "BBB", DateTime.UtcNow);
            /// string output = JsonConvert.SerializeObject(msg);
            ///  Console.WriteLine(output);
            ///  Message deserializeMsg = JsonConvert.DeserializeObject<Message>(output);
            ///  Console.WriteLine(deserializeMsg);
            ///  Console.WriteLine(msg.ToString());
            MessageId = 1;
            Console.WriteLine("Введите Имя");
            UserName = Console.ReadLine();
            string messageText = "";
            while (messageText != "exit")
            {
                GetNewMessage();
                messageText = Console.ReadLine();
                if (messageText.Length > 1)
                {
                    Message Sendmsg = new Message(UserName, messageText, DateTime.UtcNow);
                    API.SendMessage(Sendmsg);
                }
            }
        }
    }
}