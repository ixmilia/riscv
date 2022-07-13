using System;
using System.Linq;
using System.Text;
using Xunit;

namespace IxMilia.RiscV.Test
{
    public class LoadAndExecuteTests_32I : TestBase
    {
        [Fact]
        public void AnyValueSetToRegister0IsDiscarded()
        {
            var e = CreateExecutionState();
            var i = IInstructionRV32I.AddI(RegisterAddressRV32I.R0, RegisterAddressRV32I.R1, 4);
            e.Execute(i);
            Assert.Equal(0u, e.X0);
        }

        [Fact]
        public void PCIsIncrementedBy4AfterRegularInstruction()
        {
            var e = CreateExecutionState();
            var m = new ByteMemorySegmentRV32(512, 256);
            var i = InstructionRV32I_R.Add(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, RegisterAddressRV32I.R4);
            e.AddMemorySegment(m);
            m.WriteUInt(516, i.Code);
            e.PC = 516;
            e.X3 = 6;
            e.X4 = 7;
            e.ExecuteCurrent();
            Assert.Equal(520u, e.PC);
            Assert.Equal(13u, e.X2);
        }

        [Fact]
        public void BubbleSort()
        {
            var for1tst = 0x24;
            var for2tst = 0x2C;
            var exit1 = 0x60;
            var exit2 = 0x58;
            var swap = 0x7C;
            var code = $@"
                #
                # function bubble sort
                #

                # save registers
                addi x2, x2, -20                    # 0x00
                sw x1, 16(x2)                       # 0x04
                sw x22, 12(x2)                      # 0x08
                sw x21, 8(x2)                       # 0x0C
                sw x20, 4(x2)                       # 0x10
                sw x19, 0(x2)                       # 0x14

                # body
                # move parameters
                addi x21, x10, 0                    # 0x18          # x21 = data (x10)
                addi x22, x11, 0                    # 0x1C          # x22 = n (x11)

                # outer loop
                addi x19, x0, 0                     # 0x20          # i = 0
                bge x19, x22, 0x{exit1 - 0x24:X}    # 0x24 for1tst: # goto exit1 if i >= n

                # inner loop
                addi x20, x19, -1                   # 0x28          # j = i - 1
                blt x20, x0, 0x{exit2 - 0x2C:X}     # 0x2C for2tst: # goto exit2 if j < 0
                slli x5, x20, 2                     # 0x30          # x5 = j * 4
                add x5, x10, x5                     # 0x34          # x5 = v + (j * 4)
                lw x6, 0(x5)                        # 0x38          # x6 = v[j]
                lw x7, 4(x5)                        # 0x3C          # x7 = v[j + 1]
                ble x6, x7, 0x{exit2 - 0x40:X}      # 0x40          # goto exit2 if x6 < x7

                # pass all parameters and call
                addi x10, x21, 0                    # 0x44          # first swap parameter is v
                addi x11, x20, 0                    # 0x48          # second swap parameter is j
                jal x1, 0x{swap - 0x4C:X}           # 0x4C          # call swap

                # inner loop
                addi x20, x20, -1                   # 0x50          # j -= 1
                jal x0, 0x{for2tst - 0x54:X}        # 0x54          # goto for2tst

                # outer loop
                addi x19, x19, 1                    # 0x58 exit2:   # i += 1
                jal x0, 0x{for1tst - 0x5C:X}        # 0x5C          # goto for1tst

                # restore registers
                lw x19, 0(x2)                       # 0x60 exit1:
                lw x20, 4(x2)                       # 0x64
                lw x21, 8(x2)                       # 0x68
                lw x22, 12(x2)                      # 0x6C
                lw x1, 16(x2)                       # 0x70
                addi x2, x2, 20                     # 0x74

                # procedure return
                jalr x0, 0(x1)                      # 0x78          # return

                #
                # function swap
                #
                slli x6, x11, 2                     # 0x7C
                add x6, x10, x6                     # 0x80
                lw x5, 0(x6)                        # 0x84
                lw x7, 4(x6)                        # 0x88
                sw x7, 0(x6)                        # 0x8C
                sw x5, 4(x6)                        # 0x90
                jalr x0, 0(x1)                      # 0x94
";
            var instructions = IInstructionRV32I.Parse(code).ToArray();

            // set up instructions in memory
            var cs = new ByteMemorySegmentRV32(0x98, 0);
            var a = 0u;
            for (int i = 0; i < instructions.Length; i++, a += 4)
            {
                cs.WriteUInt(a, instructions[i].Code);
            }

            var ss = new ByteMemorySegmentRV32(0xFFFF, 0x200);

            // add data
            var data = new uint[] { 8, 6, 7, 5, 3, 0, 9 };
            var ds = new ByteMemorySegmentRV32(data.Length * 4, 0xA0);
            var dataStart = 0xA0u;
            a = dataStart;
            for (int i = 0; i < data.Length; i++, a += 4)
            {
                ds.WriteUInt(a, data[i]);
            }

            // run
            var e = CreateExecutionState();
            e.AddMemorySegment(cs);
            e.AddMemorySegment(ds);
            e.AddMemorySegment(ss);
            e.PC = 0; // start executing here
            e.X1 = 0x100; // jump here when done
            e.X2 = ss.BaseAddress + ss.Size; // stack pointer start
            e.X10 = dataStart;
            e.X11 = (uint)data.Length;
            var operationCount = 0;
            var log = new StringBuilder();
            for (; e.PC != 0x100; operationCount++) // run until we've jumped to the exit
            {
                if (operationCount > 1000)
                {
                    throw new Exception("Executed too many instructions; probably not going to end");
                }

                var ic = e.ReadUInt(e.PC);
                var i = ExecutionStateRV32I.Decode(ic);

                log.AppendLine($"0x{e.PC:X2}: {i}");

                e.Execute(i);
            }

            // pull out result
            a = dataStart;
            var result = new uint[data.Length];
            for (int i = 0; i < result.Length; i++, a += 4)
            {
                result[i] = ds.ReadUInt(a);
            }

            var expected = new uint[] { 0, 3, 5, 6, 7, 8, 9 };
            Assert.Equal(expected, result);
        }
    }
}
