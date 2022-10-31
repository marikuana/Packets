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
    }
}