namespace RiscV
{
    public interface IInstructionRV32I
    {
        public uint Code { get; }

        public static IInstructionRV32I Add(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => InstructionRV32I_R.Add(destination, source1, source2);
    }

    public static class InstructionRV32IExtensions
    {
        public static uint GetOpCode(this IInstructionRV32I instruction)
        {
            return BitMaskHelpers.GetBitsUint(instruction.Code, 0, 7);
        }

        public static uint SetOpCode(this IInstructionRV32I instruction, uint opcode)
        {
            return BitMaskHelpers.SetBitsUint(instruction.Code, 0, 7, opcode);
        }
    }
}
