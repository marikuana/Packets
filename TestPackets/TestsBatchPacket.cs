using NUnit.Framework;
using Packets;
using System;
using System.Numerics;

namespace TestPackets
{
    public class TestsBatchPacket
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
            Batch batch = new Batch(PacketFactory)
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