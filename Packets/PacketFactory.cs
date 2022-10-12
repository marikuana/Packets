using System.Reflection;
using System.IO;
using System;

namespace Packets
{
    public class PacketFactory
    {
        public Packet GetPacket(byte[] buffer)
        {
            var reader = new BinaryReader(new MemoryStream(buffer));
            
            PacketType packetType = (PacketType)reader.ReadUInt16();

            Packet packet;
            switch (packetType)
            {
                case PacketType.Ping:
                    packet = new Ping();
                    break;
                case PacketType.GoTo:
                    packet = new GoTo();
                    break;
                default:
                    throw new ArgumentException();
            };
            
            packet.Read(reader);
            return packet;
        }
    }
}