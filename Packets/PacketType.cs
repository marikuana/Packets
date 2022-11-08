namespace Packets
{
    public enum PacketType : ushort
    {
        Ping = 0,
        GoTo,
        Destroy,

        Request,
        Responce,

        Batch = ushort.MaxValue
    }
}