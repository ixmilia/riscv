namespace IxMilia.RiscV
{
    internal static class BitMaskHelpers
    {
        public static uint GetBitsUint(uint value, uint offset, uint length)
        {
            return (value >> (int)offset) & GetMask(length);
        }

        public static uint SetBitsUint(uint baseValue, uint offset, uint length, uint value)
        {
            var mask = GetMask(length) << (int)offset;
            var clearMask = ~mask;
            return (baseValue & clearMask) | ((value << (int)offset) & mask);
        }

        public static uint GetMask(uint size)
        {
            uint mask = 0;
            for (uint i = 0; i < size; i++)
            {
                mask = (mask << 1) | 0b1;
            }

            return mask;
        }
    }
}
