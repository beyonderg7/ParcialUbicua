using System;
using fncConsumidor2.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace fncConsumidor2
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([ServiceBusTrigger("qpar", Connection = "MyConn2")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");

            try
            {
                log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
                var data = JsonConvert.DeserializeObject<Data>(myQueueItem);

                string mensaje = "Hola " + data.aleatorio + " a la fecha " + data.DateTime;


            }
            catch (Exception e)
            {
                log.LogError($"No fue posible consumir los datos: {e.Message}");
            }
        }
    }
}
