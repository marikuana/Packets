using NUnit.Framework;
using Packets;

namespace TestPackets
{
    public class TestsPingPacket
    {
        public PacketFactory PacketFactory { get; set; }

        [SetUp]
        public void Setup()
        {
            PacketFactory = new PacketFactory();
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