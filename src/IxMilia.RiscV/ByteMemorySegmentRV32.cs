namespace IxMilia.RiscV
{
    public class ByteMemorySegmentRV32 : IMemorySegmentRV32
    {
        public uint BaseAddress { get; }

        public uint Size => (uint)Data.Length;

        public byte[] Data { get; }

        public ByteMemorySegmentRV32(int size, uint baseAddress)
            : this(new byte[size], baseAddress)
        {
        }

        public ByteMemorySegmentRV32(byte[] data, uint baseAddress)
        {
            BaseAddress = baseAddress;
            Data = data;
        }

        public byte ReadByte(uint address)
        {
            var offset = address - BaseAddress;
            return Data[offset];
        }

        public void WriteByte(uint address, byte value)
        {
            var offset = address - BaseAddress;
            Data[offset] = value;
        }

        public override string ToString() => $"[{BaseAddress:X}-{BaseAddress + Size:X}]";
    }
}
