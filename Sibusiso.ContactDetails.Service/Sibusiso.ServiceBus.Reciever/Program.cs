
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Sibusiso.ServiceBus.Reciever
{
    class Program
    {
        static async Task Main()
        {
            //setup Reciever end point
            var busConfiguration = new EndpointConfiguration("Sibusiso.ServiceBus.Reciever");
            busConfiguration.UseSerialization<XmlSerializer>();
            busConfiguration.EnableInstallers();
            busConfiguration.UsePersistence<LearningPersistence>();
            busConfiguration.UseTransport<LearningTransport>();
            busConfiguration.SendFailedMessagesTo("error");
            //starting service bus 
            var endpointInstance = await Endpoint.Start(busConfiguration)
           .ConfigureAwait(false);

            Console.WriteLine("listening......");
            Console.ReadKey();

            await endpointInstance.Stop()
                   .ConfigureAwait(false);

        }
        
    }
}
