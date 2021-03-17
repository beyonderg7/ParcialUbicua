using apiDoble.Models;
using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiDoble.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {

        [HttpPost]
        public async Task<bool> EnviarAsync([FromBody] Data data)
        {

            string connectionString = "Endpoint=sb://yabetaholding.servicebus.windows.net/;SharedAccessKeyName=Enviar;SharedAccessKey=+hyKXSMdI6dmjwNbq0zdU/8o6b18D4h/vOCPd1eba4A=;EntityPath=qlmpar";
            string queueName = "qlmpar";
            string mensaje = JsonConvert.SerializeObject(data);

            // create a Service Bus client 
            await using (ServiceBusClient client = new ServiceBusClient(connectionString))
            {
                // create a sender for the queue 
                ServiceBusSender sender = client.CreateSender(queueName);

                // create a message that we can send
                ServiceBusMessage message = new ServiceBusMessage(mensaje);

                // send the message
                await sender.SendMessageAsync(message);
                Console.WriteLine($"Sent a single message to the queue: {queueName}");
            }

            return true;
        }


        public Boolean paroImpar(int v)
        {
            if (v % 2 == 0)
            {


                return true;
            }
            else
            {

                return false;
            }



        }

    }

   

}
