namespace Packets
{
    public enum PacketType : ushort
    {
        Ping = 0,
        Create,
        Destroy,
        GoTo,

        Request,
        Responce,
        CustomData,

        Batch = ushort.MaxValue
    }
}