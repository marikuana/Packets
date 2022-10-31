using NUnit.Framework;
using Packets;
using System;
using System.Numerics;

namespace TestPackets
{
    public class TestsBatchPacket
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
            Batch batch = new Batch()
            {
                Packets = new Packet[]
                {
                    new GoTo() { EntityId = Guid.NewGuid(), Position = new Vector3(1, -2, 1.23f) },
                    new Ping(),
                    new GoTo() { EntityId = Guid.NewGuid(), Position = new Vector3(2, -3, 555) }
                }
            };

            byte[] data = batch.GetBytes();
            Packet packet = PacketFactory.GetPacket(data);

            Assert.IsInstanceOf<Batch>(packet);
            Batch newPacket = (Batch)packet;
            Assert.AreEqual(batch.Packets.Length, newPacket.Packets.Length);
            for (int i = 0; i < newPacket.Packets.Length; i++)
            {
                Assert.IsInstanceOf(batch.Packets[i].GetType(), newPacket.Packets[i]);
            }
        }
    }
}