using Models;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Sibusiso.ServiceBus.Publisher
{

    class Program
    {
        
        static async  Task Main()
        {
            //setting up published end point * I also tried busConfiguration*
            var busConfiguration = new EndpointConfiguration("Sibusiso.ServiceBus.Publisher");
            busConfiguration.UseSerialization<XmlSerializer>();
            busConfiguration.EnableInstallers();
            busConfiguration.UsePersistence<LearningPersistence>();
            busConfiguration.UseTransport<LearningTransport>();
            busConfiguration.SendFailedMessagesTo("error");

            var endpointInstance = await Endpoint.Start(busConfiguration)
           .ConfigureAwait(false);

            Console.WriteLine("Enter your name:");

            string username = Console.ReadLine();

            var message = new ServiceMessage
            {
                contant = username,
            };
            // sending messages to reciever
            await endpointInstance.Send("Sibusiso.ServiceBus.Reciever", message )
                .ConfigureAwait(false);

            Console.WriteLine(@"Hello my name is {0}",username);
            Console.ReadLine();

        }
    }
   
 
}
