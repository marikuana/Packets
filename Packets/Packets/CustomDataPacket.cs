using System.IO;

namespace Packets
{
    public class CustomDataPacket : Packet
    {
        public override PacketType packetType => PacketType.CustomData;

        public CustomData<object>[] CustomData { get; set; }

        protected internal override void Read(BinaryReader reader)
        {
            CustomData = reader.ReadCustomDatas<object>();
        }

        protected override void Write(BinaryWriter writer)
        {
            writer.Write(CustomData);
        }
    }
}