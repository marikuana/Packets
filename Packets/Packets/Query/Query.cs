using System;
using System.IO;

namespace Packets
{
    public abstract class Query : Packet
    {
        public Guid Id { get; set; }
        public Packet Packet { get; set; }

        protected override void Write(BinaryWriter writer)
        {
            writer.Write(Id);
            writer.Write(Packet.GetBytes());
        }

        protected internal override void Read(BinaryReader reader)
        {
            PacketFactory factory = new PacketFactory();

            Id = reader.ReadGuid();
            Packet = factory.GetPacket(reader.ReadBytes((int)(reader.BaseStream.Length - reader.BaseStream.Position)));
        }
    }
}