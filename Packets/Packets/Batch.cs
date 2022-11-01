using System.Collections.Generic;
using System.IO;

namespace Packets
{
    public class Batch : Packet
    {
        public override PacketType packetType => PacketType.Batch;

        public Packet[] Packets { get; set; } = new Packet[0];

        private PacketFactory _packetFactory;

        public Batch(PacketFactory packetFactory)
        {
            _packetFactory = packetFactory;
        }

        protected internal override void Read(BinaryReader reader)
        {
            var packets = new List<Packet>();
            
            List<byte> data = new List<byte>(reader.ReadBytes((int)(reader.BaseStream.Length - reader.BaseStream.Position)));
            while (data.Count > 0)
            {
                Packet packet = _packetFactory.GetPacket(data.ToArray());
                data.RemoveRange(0, packet.GetBytes().Length);
                packets.Add(packet);
            }
            Packets = packets.ToArray();
        }

        protected override void Write(BinaryWriter writer)
        {
            for (int i = 0; i < Packets.Length; i++)
            {
                writer.Write(Packets[i].GetBytes());
            }
        }
    }
}