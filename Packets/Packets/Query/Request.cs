namespace Packets
{
    public class Request : Query
    {
        public override PacketType packetType => PacketType.Request;

        public Request(PacketFactory packetFactory) : base(packetFactory)
        {
        }
    }
}