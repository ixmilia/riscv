using System.Globalization;

namespace IxMilia.RiscV
{
    internal static class ParsingExtensions
    {
        public static RegisterAddressRV32I ParseRegister(this string s)
        {
            s = s.ToLowerInvariant();
            if (!s.StartsWith("x"))
            {
                throw new NotSupportedException();
            }

            return (RegisterAddressRV32I)int.Parse(s.Substring(1));
        }

        public static uint ParseNumber(this string s)
        {
            s = s.ToLowerInvariant();
            if (s.StartsWith("0x"))
            {
                s = s.Substring(2);
            }

            return uint.Parse(s, NumberStyles.HexNumber);
        }
    }
}
