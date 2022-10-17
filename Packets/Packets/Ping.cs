namespace Packets
{
    public class Ping : Packet
    {
        public override PacketType packetType => PacketType.Ping;
    }
}