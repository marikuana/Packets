namespace Packets
{
    public enum PacketType : ushort
    {
        Ping = 0,
        GoTo,

        Batch = ushort.MaxValue
    }
}