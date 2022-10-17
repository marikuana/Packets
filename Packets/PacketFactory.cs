using System.Reflection;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Packets
{
    public class PacketFactory
    {
        private Dictionary<PacketType, ConstructorInfo> packets;

        public PacketFactory()
        {
            packets = new Dictionary<PacketType, ConstructorInfo>();
            IEnumerable <Type> packetTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(Packet)));
            foreach (Type type in packetTypes)
            {
                ConstructorInfo constructor = type.GetConstructors().First();
                Packet packet = (Packet)constructor.Invoke(new object[0]);
                packets.Add(packet.packetType, constructor);
            }
        }

        private Packet CreatePacket(PacketType packetType)
        {
            return (Packet)packets[packetType].Invoke(new object[0]);
        }

        public Packet GetPacket(byte[] buffer)
        {
            var reader = new BinaryReader(new MemoryStream(buffer));
            
            PacketType packetType = (PacketType)reader.ReadUInt16();

            Packet packet = CreatePacket(packetType);

            packet.Read(reader);
            return packet;
        }
    }
}