﻿namespace RiscV
{
    public partial class ExecutionStateRV32I
    {
        public void Execute(IInstructionRV32I instruction)
        {
            switch (instruction)
            {
                case InstructionRV32I_R ri:
                    ri.Execute(this);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}