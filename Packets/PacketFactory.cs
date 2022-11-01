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
        private IServiceProvider _service;

        public PacketFactory(IServiceProvider service)
        {
            _service = service;
            packets = new Dictionary<PacketType, ConstructorInfo>();
            IEnumerable <Type> packetTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(Packet)) && !t.IsAbstract);
            foreach (Type type in packetTypes)
            {
                ConstructorInfo constructor = type.GetConstructors().First();
                Packet packet = (Packet)constructor.Invoke(new object[constructor.GetParameters().Length]);
                packets.Add(packet.packetType, constructor);
            }
        }

        private Packet CreatePacket(PacketType packetType)
        {
            ConstructorInfo constructor = packets[packetType];
            ParameterInfo[] parameterInfos = constructor.GetParameters();
            object[] parameters = new object[parameterInfos.Length];
            for (int i = 0; i < parameterInfos.Length; i++)
            {
                parameters[i] = _service.GetService(parameterInfos[i].ParameterType);
            }
            return (Packet)constructor.Invoke(parameters);
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