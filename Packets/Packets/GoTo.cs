using System.Numerics;
using System.IO;

namespace Packets
{
    public class GoTo : Packet
    {
        public override PacketType packetType => PacketType.GoTo;

        public int EntityId { get; set; }
        public System.Numerics.Vector3 Position { get; set; }

        protected internal override void Read(BinaryReader reader)
        {
            EntityId = reader.ReadInt32();
            Position = reader.ReadVector3();
        }

        protected override void Write(BinaryWriter writer)
        {
            writer.Write(EntityId);
            writer.Write(Position);
        }
    }
}