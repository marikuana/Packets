using NUnit.Framework;
using Packets;
using System;

namespace TestPackets
{
    public class TestsPingPacket
    {
        public PacketFactory PacketFactory { get; set; }
        public IServiceProvider ServiceProvider { get; set; }
        [SetUp]
        public void Setup()
        {
            ServiceProvider = new ServiceProvider();
            PacketFactory = (PacketFactory)ServiceProvider.GetService(typeof(PacketFactory));
        }

        [Test]
        public void Test()
        {
            Ping ping = new Ping();

            byte[] data = ping.GetBytes();
            Packet packet = PacketFactory.GetPacket(data);

            Assert.IsInstanceOf<Ping>(packet);
        }
    }
}