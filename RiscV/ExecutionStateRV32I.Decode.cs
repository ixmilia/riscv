namespace RiscV
{
    public partial class ExecutionStateRV32I
    {
        public IInstructionRV32I Decode(uint code)
        {
            var opcode = BitMaskHelpers.GetBitsUint(code, 0, 7);
            switch (opcode)
            {
                case InstructionRV32I_I.LoadOpCode:
                case InstructionRV32I_I.LogicalOpCode:
                    return InstructionRV32I_I.Decode(code);
                case InstructionRV32I_R.OpCode:
                    return InstructionRV32I_R.Decode(code);
                case InstructionRV32I_U.LuiOpCode:
                    return InstructionRV32I_U.Decode(code);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
