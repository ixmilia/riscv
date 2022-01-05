namespace RiscV
{
    public interface IInstructionRV32I
    {
        public uint Code { get; }

        public uint OpCode => BitMaskHelpers.GetBitsUint(Code, 0, 7);

        public static IInstructionRV32I Add(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => InstructionRV32I_R.Add(destination, source1, source2);
        public static IInstructionRV32I Sub(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => InstructionRV32I_R.Sub(destination, source1, source2);
        public static IInstructionRV32I Sll(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => InstructionRV32I_R.Sll(destination, source1, source2);
        public static IInstructionRV32I Srl(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => InstructionRV32I_R.Srl(destination, source1, source2);
        public static IInstructionRV32I Sra(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => InstructionRV32I_R.Sra(destination, source1, source2);
        public static IInstructionRV32I Slt(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => InstructionRV32I_R.Slt(destination, source1, source2);
    }
}
