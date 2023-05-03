using System;
using Newtonsoft.Json;
namespace ConsoleClientMessager
{
    class Program
    { 
    static void Main(string[] args)
        {
            Message msg = new Message("AAA", "BBB", DateTime.UtcNow);
            string output = JsonConvert.SerializeObject(msg);
            Console.WriteLine(output);
            Message deserializeMsg = JsonConvert.DeserializeObject<Message>(output);
            Console.WriteLine(deserializeMsg);
            Console.WriteLine(msg.ToString());
        }
    }
}