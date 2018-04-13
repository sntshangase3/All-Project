using Models;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sibusiso.ServiceBus.Reciever
{
    public class MessageHandler: IHandleMessages<ServiceMessage>
    {
        //lister handle for incoming messages
        public Task Handle(ServiceMessage message, IMessageHandlerContext context)
        {

            Console.WriteLine(@"Hello {0}, I am your father!", message.contant);
            return Task.CompletedTask;
        }

    }

}
