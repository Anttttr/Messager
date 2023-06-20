using ConsoleClientMessager;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Messager : ControllerBase
    {
        static List<Message> ListOfMessages = new List<Message>();

        // GET api/<Messager>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            string OutputString = "Not found";
            if ((id < ListOfMessages.Count) && (id >= 0))
            {
                OutputString = JsonConvert.SerializeObject(ListOfMessages[id]);
            }
            Console.WriteLine(String.Format("Запрошено сообщение {0} : {1}", id, OutputString));
            return OutputString;
        }

        // POST api/<Messager>
        [HttpPost]
        public IActionResult SendMessage([FromBody] Message message)
        {
            if (message == null)
            {
                Console.WriteLine(message);
                return BadRequest();
            }
            ListOfMessages.Add(message);
            Console.WriteLine(String.Format("Всего: {0} Отправлено: {1}", ListOfMessages.Count, message));
            return new OkResult();
        }

    }
}
