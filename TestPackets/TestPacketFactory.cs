using NUnit.Framework;
using Packets;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace TestPackets
{
    public class TestPacketFactory
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
        public void TestGetPacket()
        {
            Packet[] packets = new Packet[]
            {
                new GoTo() { EntityId = Guid.NewGuid(), Position = new Vector3(1, -2, 1.23f) },
                new Ping(),
                new GoTo() { EntityId = Guid.NewGuid(), Position = new Vector3(2, -3, 555) }
            };
            List<byte> data = new List<byte>();
            foreach (var p in packets)
                data.AddRange(p.GetBytes());

            for (int i = 0; i < packets.Length; i++)
            {
                int count = PacketFactory.GetPacket(data.ToArray(), out Packet packet);
                data.RemoveRange(0, count);

                Assert.IsInstanceOf(packets[i].GetType(), packet);
                Assert.AreEqual(packets[i].GetBytes(), packet.GetBytes());
            }
        }
    }
}