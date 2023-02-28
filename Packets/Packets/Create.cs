using System.IO;
using System;

namespace Packets
{
    public class Create : Packet
    {
        public override PacketType packetType => PacketType.Create;

        public Guid EntityId { get; set; }
        public ObjectType ObjectType { get; set; }
        public CustomData[] CustomData { get; set; }

        protected internal override void Read(BinaryReader reader)
        {
            EntityId = reader.ReadGuid();
            ObjectType = (ObjectType)reader.ReadInt16();
            CustomData = reader.ReadCustomDatas();
        }

        protected override void Write(BinaryWriter writer)
        {
            writer.Write(EntityId);
            writer.Write((short)ObjectType);
            writer.Write(CustomData);
        }
    }
}