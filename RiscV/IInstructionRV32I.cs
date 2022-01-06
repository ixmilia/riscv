namespace RiscV
{
    public interface IInstructionRV32I
    {
        public uint Code { get; }

        public uint OpCode => BitMaskHelpers.GetBitsUint(Code, 0, 7);

        public static IInstructionRV32I AddI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int immediate) => InstructionRV32I_I.AddI(destination, source1, immediate);
        public static IInstructionRV32I SltI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int immediate) => InstructionRV32I_I.SltI(destination, source1, immediate);
        public static IInstructionRV32I SltIU(RegisterAddressRV32I destination, RegisterAddressRV32I source1, uint immediate) => InstructionRV32I_I.SltIU(destination, source1, immediate);
        public static IInstructionRV32I AndI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int immediate) => InstructionRV32I_I.AndI(destination, source1, immediate);
        public static IInstructionRV32I OrI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int immediate) => InstructionRV32I_I.OrI(destination, source1, immediate);
        public static IInstructionRV32I XorI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int immediate) => InstructionRV32I_I.XorI(destination, source1, immediate);
        public static IInstructionRV32I SllI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, uint shiftAmount) => InstructionRV32I_I.SllI(destination, source1, shiftAmount);

        public static IInstructionRV32I Add(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => InstructionRV32I_R.Add(destination, source1, source2);
        public static IInstructionRV32I Slt(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => InstructionRV32I_R.Slt(destination, source1, source2);
        public static IInstructionRV32I Sltu(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => InstructionRV32I_R.Sltu(destination, source1, source2);
        public static IInstructionRV32I And(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => InstructionRV32I_R.And(destination, source1, source2);
        public static IInstructionRV32I Or(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => InstructionRV32I_R.Or(destination, source1, source2);
        public static IInstructionRV32I Xor(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => InstructionRV32I_R.Xor(destination, source1, source2);
        public static IInstructionRV32I Sll(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => InstructionRV32I_R.Sll(destination, source1, source2);
        public static IInstructionRV32I Srl(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => InstructionRV32I_R.Srl(destination, source1, source2);
        public static IInstructionRV32I Sub(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => InstructionRV32I_R.Sub(destination, source1, source2);
        public static IInstructionRV32I Sra(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => InstructionRV32I_R.Sra(destination, source1, source2);
    }
}
