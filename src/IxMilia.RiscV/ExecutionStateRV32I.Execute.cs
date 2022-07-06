namespace IxMilia.RiscV
{
    public partial class ExecutionStateRV32I
    {
        public void ExecuteCurrent()
        {
            var ic = ReadUInt(PC);
            var i = Decode(ic);
            Execute(i);
        }

        public void Execute(IInstructionRV32I instruction)
        {
            switch (instruction)
            {
                case InstructionRV32I_B bi:
                    bi.Execute(this);
                    break;
                case InstructionRV32I_I ii:
                    ii.Execute(this);
                    break;
                case InstructionRV32I_R ri:
                    ri.Execute(this);
                    break;
                case InstructionRV32I_S si:
                    si.Execute(this);
                    break;
                case InstructionRV32I_U ui:
                    ui.Execute(this);
                    break;
                case InstructionRV32I_J ji:
                    ji.Execute(this);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
