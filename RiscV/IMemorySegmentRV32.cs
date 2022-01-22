namespace RiscV
{
    public interface IMemorySegmentRV32
    {
        public uint BaseAddress { get; }
        public uint Size { get; }
        public byte ReadByte(uint address);
        public void WriteByte(uint address, byte value);
    }

    public static class IMemorySegmentRV32Extensions
    {
        public static bool ContainsAddress(this IMemorySegmentRV32 ms, uint address)
        {
            return address >= ms.BaseAddress && address < ms.BaseAddress + ms.Size;
        }

        public static uint ReadUInt(this IMemorySegmentRV32 ms, uint address)
        {
            var b1 = ms.ReadByte(address);
            var b2 = ms.ReadByte(address + 1);
            var b3 = ms.ReadByte(address + 2);
            var b4 = ms.ReadByte(address + 3);
            var result = ByteHelpers.UIntFromBytes(b1, b2, b3, b4);
            return result;
        }

        public static void WriteUInt(this IMemorySegmentRV32 ms, uint address, uint value)
        {
            var b1 = (byte)(value & 0xFF);
            var b2 = (byte)((value >> 8) & 0xFF);
            var b3 = (byte)((value >> 16) & 0xFF);
            var b4 = (byte)((value >> 24) & 0xFF);
            ms.WriteByte(address, b1);
            ms.WriteByte(address + 1, b2);
            ms.WriteByte(address + 2, b3);
            ms.WriteByte(address + 3, b4);
        }
    }
}
