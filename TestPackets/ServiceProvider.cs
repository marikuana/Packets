using Microsoft.Extensions.Logging;
using Packets;
using System;

namespace TestPackets
{
    public class ServiceProvider : IServiceProvider
    {
        private PacketFactory packetFactory;
        private ILogger<PacketFactory> logger;

        public ServiceProvider()
        {
            packetFactory = new PacketFactory(this, logger);
        }

        public object? GetService(Type serviceType)
        {
            return packetFactory;
        }
    }
}