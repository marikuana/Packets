namespace Packets
{
    public enum PacketType : ushort
    {
        Ping = 0,
        GoTo,

        Request,
        Responce,

        Batch = ushort.MaxValue
    }
}