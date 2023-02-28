using System.Numerics;
using System.IO;
using System;

namespace Packets
{
    public static class BinaryReaderExtensions
    {
        public static System.Numerics.Vector3 ReadVector3(this BinaryReader reader)
        {
            return new System.Numerics.Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
        }

        public static Guid ReadGuid(this BinaryReader reader)
        {
            int count = reader.ReadInt32();
            return new Guid(reader.ReadBytes(count));
        }

        public static CustomData ReadCustomData(this BinaryReader reader)
        {
            TypeCode typeCode = (TypeCode)reader.ReadInt32();
            object data = reader.ReadObject(typeCode);
            return new CustomData()
            {
                Type = typeCode,
                Data = data
            };
        }

        public static CustomData[] ReadCustomDatas(this BinaryReader reader)
        {
            int count = reader.ReadInt32();
            CustomData[] data = new CustomData[count];
            for (int i = 0; i < count; i++)
                data[i] = ReadCustomData(reader);
            return data;
        }

        public static object ReadObject(this BinaryReader reader, TypeCode typeCode)
        {
            return typeCode switch
            {
                TypeCode.Boolean => reader.ReadBoolean(),
                TypeCode.Byte => reader.ReadByte(),
                TypeCode.Char => reader.PeekChar(),
                TypeCode.Decimal => reader.ReadDecimal(),
                TypeCode.Double => reader.ReadDouble(),
                TypeCode.Int16 => reader.ReadInt16(),
                TypeCode.Int32 => reader.ReadInt32(),
                TypeCode.Int64 => reader.ReadInt64(),
                TypeCode.SByte => reader.ReadSByte(),
                TypeCode.Single => reader.ReadSingle(),
                TypeCode.String => reader.ReadString(),
                TypeCode.UInt16 => reader.ReadUInt16(),
                TypeCode.UInt32 => reader.ReadUInt32(),
                TypeCode.UInt64 => reader.ReadUInt64(),
            };
        }
    }
}