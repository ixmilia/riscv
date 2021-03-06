using System.Reflection.Emit;

namespace IxMilia.RiscV
{
    public struct InstructionRV32I_B : IInstructionRV32I
    {
        public const uint BranchOpCode = 0b1100011;

        public const int BeqFunct3 = 0b000;
        public const int BneFunct3 = 0b001;
        public const int BltFunct3 = 0b100;
        public const int BltUFunct3 = 0b110;
        public const int BgeFunct3 = 0b101;
        public const int BgeUFunct3 = 0b111;

        public uint Code { get; internal set; }

        private InstructionRV32I_B(uint code)
        {
            Code = code;
        }

        public InstructionRV32I_B(uint funct3, RegisterAddressRV32I source1, RegisterAddressRV32I source2, int immediate)
        {
            Code = BranchOpCode;
            Function3 = funct3;
            Source1 = source1;
            Source2 = source2;
            Immediate = immediate;
        }

        public uint Function3
        {
            get => BitMaskHelpers.GetBitsUint(Code, 12, 3);
            set => Code = BitMaskHelpers.SetBitsUint(Code, 12, 3, value);
        }

        public RegisterAddressRV32I Source1
        {
            get => (RegisterAddressRV32I)BitMaskHelpers.GetBitsUint(Code, 15, 5);
            set => Code = BitMaskHelpers.SetBitsUint(Code, 15, 5, (uint)value);
        }

        public RegisterAddressRV32I Source2
        {
            get => (RegisterAddressRV32I)BitMaskHelpers.GetBitsUint(Code, 20, 5);
            set => Code = BitMaskHelpers.SetBitsUint(Code, 20, 5, (uint)value);
        }

        public int Immediate
        {
            get
            {
                var imm_4_1 = BitMaskHelpers.GetBitsUint(Code, 8, 4);
                var imm_10_5 = BitMaskHelpers.GetBitsUint(Code, 25, 6);
                var imm_11 = BitMaskHelpers.GetBitsUint(Code, 7, 1);
                var imm_12 = BitMaskHelpers.GetBitsUint(Code, 31, 1);
                var result = (int)((imm_12 << 12) + (imm_11 << 11) + (imm_10_5 << 5) + (imm_4_1 << 1));
                result = result << 12 >> 12;
                return result;
            }
            set
            {
                var v = (uint)((value << 12) >> 12);
                Code = BitMaskHelpers.SetBitsUint(Code, 8, 4, v >> 1);
                Code = BitMaskHelpers.SetBitsUint(Code, 25, 6, v >> 5);
                Code = BitMaskHelpers.SetBitsUint(Code, 7, 1, v >> 11);
                Code = BitMaskHelpers.SetBitsUint(Code, 31, 1, v >> 12);
            }
        }

        internal static InstructionRV32I_B Decode(uint code)
        {
            var i = new InstructionRV32I_B(code);
            switch ((((IInstructionRV32I)i).OpCode, BitMaskHelpers.GetBitsUint(code, 12, 3)))
            {
                case (BranchOpCode, BeqFunct3):
                case (BranchOpCode, BneFunct3):
                case (BranchOpCode, BltFunct3):
                case (BranchOpCode, BltUFunct3):
                case (BranchOpCode, BgeFunct3):
                case (BranchOpCode, BgeUFunct3):
                    // perfectly fine function
                    break;
                default:
                    throw new NotSupportedException();
            }

            return i;
        }

        public static InstructionRV32I_B Beq(RegisterAddressRV32I source1, RegisterAddressRV32I source2, int immediate) => new InstructionRV32I_B(BeqFunct3, source1, source2, immediate);
        public static InstructionRV32I_B Bne(RegisterAddressRV32I source1, RegisterAddressRV32I source2, int immediate) => new InstructionRV32I_B(BneFunct3, source1, source2, immediate);
        public static InstructionRV32I_B Blt(RegisterAddressRV32I source1, RegisterAddressRV32I source2, int immediate) => new InstructionRV32I_B(BltFunct3, source1, source2, immediate);
        public static InstructionRV32I_B BltU(RegisterAddressRV32I source1, RegisterAddressRV32I source2, int immediate) => new InstructionRV32I_B(BltUFunct3, source1, source2, immediate);
        public static InstructionRV32I_B Bge(RegisterAddressRV32I source1, RegisterAddressRV32I source2, int immediate) => new InstructionRV32I_B(BgeFunct3, source1, source2, immediate);
        public static InstructionRV32I_B BgeU(RegisterAddressRV32I source1, RegisterAddressRV32I source2, int immediate) => new InstructionRV32I_B(BgeUFunct3, source1, source2, immediate);

        public static InstructionRV32I_B Bgt(RegisterAddressRV32I source1, RegisterAddressRV32I source2, int immediate) => Blt(source2, source1, immediate);
        public static InstructionRV32I_B BgtU(RegisterAddressRV32I source1, RegisterAddressRV32I source2, int immediate) => BltU(source2, source1, immediate);
        public static InstructionRV32I_B Ble(RegisterAddressRV32I source1, RegisterAddressRV32I source2, int immediate) => Bge(source2, source1, immediate);
        public static InstructionRV32I_B BleU(RegisterAddressRV32I source1, RegisterAddressRV32I source2, int immediate) => BgeU(source2, source1, immediate);

        internal void Execute(ExecutionStateRV32I executionState)
        {
            switch (Function3)
            {
                case BeqFunct3:
                    if (executionState.GetRegisterValue(Source1) == executionState.GetRegisterValue(Source2))
                    {
                        executionState.PC = (uint)(executionState.PC + Immediate);
                    }
                    else
                    {
                        executionState.PC += 4;
                    }
                    break;
                case BneFunct3:
                    if (executionState.GetRegisterValue(Source1) != executionState.GetRegisterValue(Source2))
                    {
                        executionState.PC = (uint)(executionState.PC + Immediate);
                    }
                    else
                    {
                        executionState.PC += 4;
                    }
                    break;
                case BltFunct3:
                    if ((int)executionState.GetRegisterValue(Source1) < (int)executionState.GetRegisterValue(Source2))
                    {
                        executionState.PC = (uint)(executionState.PC + Immediate);
                    }
                    else
                    {
                        executionState.PC += 4;
                    }
                    break;
                case BltUFunct3:
                    if (executionState.GetRegisterValue(Source1) < executionState.GetRegisterValue(Source2))
                    {
                        executionState.PC = (uint)(executionState.PC + Immediate);
                    }
                    else
                    {
                        executionState.PC += 4;
                    }
                    break;
                case BgeFunct3:
                    if ((int)executionState.GetRegisterValue(Source1) >= (int)executionState.GetRegisterValue(Source2))
                    {
                        executionState.PC = (uint)(executionState.PC + Immediate);
                    }
                    else
                    {
                        executionState.PC += 4;
                    }
                    break;
                case BgeUFunct3:
                    if (executionState.GetRegisterValue(Source1) >= executionState.GetRegisterValue(Source2))
                    {
                        executionState.PC = (uint)(executionState.PC + Immediate);
                    }
                    else
                    {
                        executionState.PC += 4;
                    }
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        public override string ToString()
        {
            var instructionName = Function3 switch
            {
                BeqFunct3 => "beq",
                BneFunct3 => "bne",
                BgeFunct3 => "bge",
                BgeUFunct3 => "bgeu",
                BltFunct3 => "blt",
                BltUFunct3 => "bltu",
                _ => throw new NotImplementedException()
            };

            return $"{instructionName} {Source1.ToDisplayString()}, {Source2.ToDisplayString()}, 0x{Immediate:X}";
        }

        internal static bool TryParseRemainder(string instruction, string s, out InstructionRV32I_B result)
        {
            result = default;
            var parts = s.Split(',').Select(p => p.Trim()).ToArray();
            if (parts.Length != 3)
            {
                return false;
            }

            Func<RegisterAddressRV32I, RegisterAddressRV32I, int, InstructionRV32I_B>? creator = instruction switch
            {
                "beq" => Beq,
                "bne" => Bne,
                "ble" => Ble,
                "bleu" => BleU,
                "blt" => Blt,
                "bltu" => BltU,
                "bge" => Bge,
                "bgeu" => BgeU,
                "bgt" => Bgt,
                "bgtu" => BgtU,
                _ => null,
            };

            if (creator is null)
            {
                return false;
            }

            var source1 = parts[0].ParseRegister();
            var source2 = parts[1].ParseRegister();
            var offset = (int)parts[2].ParseNumber();

            result = creator(source1, source2, offset);
            return true;
        }
    }
}
