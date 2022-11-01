using Packets;
using System;

namespace TestPackets
{
    public class ServiceProvider : IServiceProvider
    {
        private PacketFactory packetFactory;

        public ServiceProvider()
        {
            packetFactory = new PacketFactory(this);
        }

        public object? GetService(Type serviceType)
        {
            return packetFactory;
        }
    }
}