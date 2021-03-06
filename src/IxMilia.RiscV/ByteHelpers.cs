namespace IxMilia.RiscV
{
    internal static class ByteHelpers
    {
        public static ushort UShortFromBytes(byte b1, byte b2)
        {
            var result = (ushort)((b2 << 8) + b1);
            return result;
        }

        public static uint UIntFromBytes(byte b1, byte b2, byte b3, byte b4)
        {
            var result = (uint)((b4 << 24) | (b3 << 16) | (b2 << 8) | b1);
            return result;
        }
    }
}
