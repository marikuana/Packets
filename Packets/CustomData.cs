using System;

namespace Packets
{
    public class CustomData<T>
    {
        public TypeCode Type { get; set; }
        public T Data { get; set; }
    }
}