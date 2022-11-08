using System.IO;
using System;

namespace Packets
{
    public class Destroy : Packet
    {
        public override PacketType packetType => PacketType.Destroy;

        public Guid EntityId { get; set; }

        protected internal override void Read(BinaryReader reader)
        {
            EntityId = reader.ReadGuid();
        }

        protected override void Write(BinaryWriter writer)
        {
            writer.Write(EntityId);
        }
    }
}