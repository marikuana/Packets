using System.Numerics;
using System.IO;

namespace Packets
{
    public static class BinaryReaderExtensions
    {
        public static System.Numerics.Vector3 ReadVector3(this BinaryReader reader)
        {
            return new System.Numerics.Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
        }
    }
}