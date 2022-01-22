namespace RiscV
{
    public class ByteMemorySegmentRV32 : IMemorySegmentRV32
    {
        public uint BaseAddress { get; }

        public uint Size => (uint)(BaseAddress + Data.Length);

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
            return Data[address - BaseAddress];
        }

        public void WriteByte(uint address, byte value)
        {
            Data[address - BaseAddress] = value;
        }
    }
}
