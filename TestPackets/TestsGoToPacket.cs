using NUnit.Framework;
using Packets;

namespace TestPackets
{
    public class TestsGoToPacket
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
            GoTo goTo = new GoTo() { EntityId = 1, Position = new System.Numerics.Vector3(1, -2, 1.23f) };

            byte[] data = goTo.GetBytes();
            Packet packet = PacketFactory.GetPacket(data);

            Assert.IsInstanceOf<GoTo>(packet);
            GoTo newPacket = (GoTo)packet;
            Assert.AreEqual(goTo.EntityId, newPacket.EntityId);
            Assert.AreEqual(goTo.Position, newPacket.Position);
        }
    }
}