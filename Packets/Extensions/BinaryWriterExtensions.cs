using System.Numerics;
using System.IO;
using System;

namespace Packets
{
    public static class BinaryWriterExtensions
    {
        public static void Write(this BinaryWriter writer, Vector3 vector)
        {
            writer.Write(vector.X);
            writer.Write(vector.Y);
            writer.Write(vector.Z);
        }

        public static void Write(this BinaryWriter writer, Guid guid)
        {
            byte[] data = guid.ToByteArray();
            writer.Write(data.Length);
            writer.Write(data);
        }

        public static void Write(this BinaryWriter writer, CustomData[] customData)
        {
            writer.Write(customData.Length);
            for (int i = 0; i < customData.Length; i++)
                writer.Write(customData[i]);          
        }

        public static void Write(this BinaryWriter writer, CustomData customData)
        {
            TypeCode typeCode = customData.Type;
            writer.Write((int)typeCode);
            writer.Write(typeCode, customData.Data);
        }

        public static void Write(this BinaryWriter writer, TypeCode typeCode, object value)
        {
            switch (typeCode)
            {
                case TypeCode.Boolean:
                    writer.Write((bool)value);
                    break;
                case TypeCode.Byte:
                    writer.Write((byte)value);
                    break;
                case TypeCode.Char:
                    writer.Write((char)value);
                    break;
                case TypeCode.Decimal:
                    writer.Write((decimal)value);
                    break;
                case TypeCode.Double:
                    writer.Write((double)value);
                    break;
                case TypeCode.Int16:
                    writer.Write((short)value);
                    break;
                case TypeCode.Int32:
                    writer.Write((int)value);
                    break;
                case TypeCode.Int64:
                    writer.Write((long)value);
                    break;
                case TypeCode.SByte:
                    writer.Write((sbyte)value);
                    break;
                case TypeCode.Single:
                    writer.Write((float)value);
                    break;
                case TypeCode.String:
                    writer.Write((string)value);
                    break;
                case TypeCode.UInt16:
                    writer.Write((ushort)value);
                    break;
                case TypeCode.UInt32:
                    writer.Write((uint)value);
                    break;
                case TypeCode.UInt64:
                    writer.Write((ulong)value);
                    break;
                case TypeCode.DateTime:
                case TypeCode.DBNull:
                case TypeCode.Empty:
                case TypeCode.Object:
                    break;
                default:
                    break;
            }
        }
    }
}