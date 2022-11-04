namespace Packets
{
    public class ResponcePacketFactory
    {
        private PacketFactory _packetFactory;

        public ResponcePacketFactory(PacketFactory packetFactory)
        {
            _packetFactory = packetFactory;
        }

        public Response Create()
        {
            return new Response(_packetFactory);
        }

        public Response CreateFromRequest(Request request)
        {
            Response response = Create();
            response.Id = request.Id;
            return response;
        }
    }
}