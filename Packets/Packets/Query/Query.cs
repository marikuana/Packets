using System;
using System.IO;

namespace Packets
{
    public abstract class Query : Packet
    {
        public Guid Id { get; set; }
        public Packet Packet { get; set; }

        private PacketFactory _packetFactory;

        public Query(PacketFactory packetFactory)
        {
            _packetFactory = packetFactory;
        }

        protected override void Write(BinaryWriter writer)
        {
            writer.Write(Id);
            writer.Write(Packet.GetBytes());
        }

        protected internal override void Read(BinaryReader reader)
        {
            Id = reader.ReadGuid();
            Packet = _packetFactory.GetPacket(reader.ReadBytes((int)(reader.BaseStream.Length - reader.BaseStream.Position)));
        }
    }
}