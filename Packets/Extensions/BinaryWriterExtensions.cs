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
    }
}