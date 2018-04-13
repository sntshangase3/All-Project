using NServiceBus;
using System;

namespace Models
{
    public class ServiceMessage : ICommand
    {
        public string contant { get; set; }
    }
}
