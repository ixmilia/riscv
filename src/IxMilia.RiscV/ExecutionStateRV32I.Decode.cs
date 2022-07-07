namespace IxMilia.RiscV
{
    public partial class ExecutionStateRV32I
    {
        public static IInstructionRV32I Decode(uint code)
        {
            var opcode = BitMaskHelpers.GetBitsUint(code, 0, 7);
            switch (opcode)
            {
                case InstructionRV32I_B.BranchOpCode:
                    return InstructionRV32I_B.Decode(code);
                case InstructionRV32I_I.LoadOpCode:
                case InstructionRV32I_I.LogicalOpCode:
                case InstructionRV32I_I.JalrOpCode:
                    return InstructionRV32I_I.Decode(code);
                case InstructionRV32I_J.JalOpCode:
                    return InstructionRV32I_J.Decode(code);
                case InstructionRV32I_R.OpCode:
                    return InstructionRV32I_R.Decode(code);
                case InstructionRV32I_S.OpCode:
                    return InstructionRV32I_S.Decode(code);
                case InstructionRV32I_U.LuiOpCode:
                case InstructionRV32I_U.AuiPCOpCode:
                    return InstructionRV32I_U.Decode(code);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
