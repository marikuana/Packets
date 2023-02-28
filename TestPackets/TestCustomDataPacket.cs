using NUnit.Framework;
using Packets;
using System;

namespace TestPackets
{
    public class TestCustomDataPacket
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
            CustomDataPacket customDataPacket = new CustomDataPacket()
            {
                CustomData = new CustomData[]
                {
                    new CustomData
                    {
                        Type = TypeCode.String,
                        Data = "123sff3t&*gO908r(Ь◙ф└ф.xчоIrФ♥"
                    },
                    new CustomData
                    {
                        Type = TypeCode.Boolean,
                        Data = true
                    }
                }
            };

            byte[] data = customDataPacket.GetBytes();
            Packet packet = PacketFactory.GetPacket(data);

            Assert.IsInstanceOf<CustomDataPacket>(packet);
            CustomDataPacket newPacket = (CustomDataPacket)packet;
            Assert.AreEqual(customDataPacket.CustomData.Length, newPacket.CustomData.Length);
            for (int i = 0; i < customDataPacket.CustomData.Length; i++)
            {
                Assert.AreEqual(customDataPacket.CustomData[i].Type, newPacket.CustomData[i].Type);
                Assert.AreEqual(customDataPacket.CustomData[i].Data, newPacket.CustomData[i].Data);
            }
        }
    }
}