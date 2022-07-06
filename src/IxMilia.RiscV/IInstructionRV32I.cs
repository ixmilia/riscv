namespace IxMilia.RiscV
{
    public interface IInstructionRV32I
    {
        public uint Code { get; }

        public uint OpCode => BitMaskHelpers.GetBitsUint(Code, 0, 7);

        public static IInstructionRV32I SW(RegisterAddressRV32I source1, RegisterAddressRV32I source2, int offset) => InstructionRV32I_S.SW(source1, source2, offset);

        public static IInstructionRV32I LW(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int immediate) => InstructionRV32I_I.LW(destination, source1, immediate);
        public static IInstructionRV32I AddI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int immediate) => InstructionRV32I_I.AddI(destination, source1, immediate);
        public static IInstructionRV32I SltI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int immediate) => InstructionRV32I_I.SltI(destination, source1, immediate);
        public static IInstructionRV32I SltIU(RegisterAddressRV32I destination, RegisterAddressRV32I source1, uint immediate) => InstructionRV32I_I.SltIU(destination, source1, immediate);
        public static IInstructionRV32I AndI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int immediate) => InstructionRV32I_I.AndI(destination, source1, immediate);
        public static IInstructionRV32I OrI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int immediate) => InstructionRV32I_I.OrI(destination, source1, immediate);
        public static IInstructionRV32I XorI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int immediate) => InstructionRV32I_I.XorI(destination, source1, immediate);
        public static IInstructionRV32I Not(RegisterAddressRV32I destination, RegisterAddressRV32I source1) => InstructionRV32I_I.Not(destination, source1);
        public static IInstructionRV32I SllI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, uint shiftAmount) => InstructionRV32I_I.SllI(destination, source1, shiftAmount);
        public static IInstructionRV32I SrlI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, uint shiftAmount) => InstructionRV32I_I.SrlI(destination, source1, shiftAmount);
        public static IInstructionRV32I SraI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, uint shiftAmount) => InstructionRV32I_I.SraI(destination, source1, shiftAmount);
        public static IInstructionRV32I Nop() => InstructionRV32I_I.Nop();

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

        public static IInstructionRV32I Lui(RegisterAddressRV32I destination, uint immediate) => InstructionRV32I_U.Lui(destination, immediate);
        public static IInstructionRV32I AuiPC(RegisterAddressRV32I destination, uint immediate) => InstructionRV32I_U.AuiPC(destination, immediate);

        public static IInstructionRV32I Jal(RegisterAddressRV32I destination, int addressOffset) => InstructionRV32I_J.Jal(destination, addressOffset);

        public static IInstructionRV32I Jalr(RegisterAddressRV32I destination, RegisterAddressRV32I source, int offset) => InstructionRV32I_I.Jalr(destination, source, offset);

        public static IInstructionRV32I Beq(RegisterAddressRV32I source1, RegisterAddressRV32I source2, int immediate) => InstructionRV32I_B.Beq(source1, source2, immediate);
        public static IInstructionRV32I Bne(RegisterAddressRV32I source1, RegisterAddressRV32I source2, int immediate) => InstructionRV32I_B.Bne(source1, source2, immediate);
        public static IInstructionRV32I Blt(RegisterAddressRV32I source1, RegisterAddressRV32I source2, int immediate) => InstructionRV32I_B.Blt(source1, source2, immediate);
        public static IInstructionRV32I BltU(RegisterAddressRV32I source1, RegisterAddressRV32I source2, int immediate) => InstructionRV32I_B.BltU(source1, source2, immediate);
        public static IInstructionRV32I Bge(RegisterAddressRV32I source1, RegisterAddressRV32I source2, int immediate) => InstructionRV32I_B.Bge(source1, source2, immediate);
    }
}
