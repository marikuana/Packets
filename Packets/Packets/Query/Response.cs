namespace Packets
{
    public class Response : Query
    {
        public override PacketType packetType => PacketType.Responce;
    }
}