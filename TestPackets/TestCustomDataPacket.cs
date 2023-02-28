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
                CustomData = new CustomData<object>()
                {
                    Type = TypeCode.String,
                    Data = "123sff3t&*gO908r(Ь◙ф└ф.xчоIrФ♥"
                } 
            };

            byte[] data = customDataPacket.GetBytes();
            Packet packet = PacketFactory.GetPacket(data);

            Assert.IsInstanceOf<CustomDataPacket>(packet);
            CustomDataPacket newPacket = (CustomDataPacket)packet;
            Assert.AreEqual(customDataPacket.CustomData.Type, newPacket.CustomData.Type);
            Assert.AreEqual(customDataPacket.CustomData.Data, newPacket.CustomData.Data);
        }
    }
}