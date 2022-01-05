﻿using Xunit;

namespace RiscV.Test
{
    public class ExecutionTests_32I_R
    {
        private static ExecutionStateRV32I CreateExecutionState() => new ExecutionStateRV32I();

        [Fact]
        public void Add()
        {
            var e = CreateExecutionState();
            e.X2 = 2;
            e.X4 = 4;
            var add = IInstructionRV32I.Add(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, RegisterAddressRV32I.R4);
            e.Execute(add);
            Assert.Equal(6u, e.X17);
        }
    }
}
