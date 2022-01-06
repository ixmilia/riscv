﻿using Xunit;

namespace RiscV.Test
{
    public class ExecutionTests_32I_I : TestBase
    {
        private static ExecutionStateRV32I CreateExecutionState() => new ExecutionStateRV32I();

        protected static void AssertEqualBinary(uint expected, uint actual)
        {
            var indices = new[] { 8, 16, 24 };
            var expectedS = AsBinary(expected, indices);
            var actualS = AsBinary(actual, indices);
            Assert.Equal(expectedS, actualS);
        }

        [Fact]
        public void AddI()
        {
            var e = CreateExecutionState();
            e.X2 = 2;
            var add = IInstructionRV32I.AddI(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, 4);
            e.Execute(add);
            AssertEqualBinary(6u, e.X17);
        }
    }
}