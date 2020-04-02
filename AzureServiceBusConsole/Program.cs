using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;

namespace AzureServiceBusConsole
{
    public class account
    {
        public string accountid { get; set; }
        public string accountname { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myaccount = new account();
            myaccount.accountid = "ASB-0003";
            myaccount.accountname = "Service Bus Company #03";

            string output = JsonConvert.SerializeObject(myaccount).ToString();

            Console.WriteLine(String.Format("Contents: {0}", output));

            var connectionString = "Endpoint=sb://mufife.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Z1HFS+MldjXsehPBOktr5fbxMZg7P8aJM2WxoCeFP+0=";
            var queueName = "console";

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);
            var message = new BrokeredMessage(output.ToString());

            Console.WriteLine(String.Format("Message id: {0}", message.MessageId));

            client.Send(message);

            Console.WriteLine("Message successfully sent! Press ENTER to exit program");
            Console.ReadLine();
        }
    }
}
