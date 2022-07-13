using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace IxMilia.RiscV
{
    public struct InstructionRV32I_S : IInstructionRV32I
    {
        public const uint OpCode = 0b0100011;

        public const uint SwFunct3 = 0b010;
        public const uint ShFunct3 = 0b001;
        public const uint SbFunct3 = 0b000;

        public uint Code { get; internal set; }

        private InstructionRV32I_S(uint code)
        {
            Code = code;
        }

        public InstructionRV32I_S(uint function3, RegisterAddressRV32I source1, RegisterAddressRV32I source2, int immediate)
        {
            Code = OpCode;
            Function3 = function3;
            SourceRegister1 = source1;
            SourceRegister2 = source2;
            ImmediateValue = immediate;
        }

        public uint Function3
        {
            get => BitMaskHelpers.GetBitsUint(Code, 12, 3);
            set => Code = BitMaskHelpers.SetBitsUint(Code, 12, 3, value);
        }

        public RegisterAddressRV32I SourceRegister1
        {
            get => (RegisterAddressRV32I)BitMaskHelpers.GetBitsUint(Code, 15, 5);
            set => Code = BitMaskHelpers.SetBitsUint(Code, 15, 5, (uint)value);
        }

        public RegisterAddressRV32I SourceRegister2
        {
            get => (RegisterAddressRV32I)BitMaskHelpers.GetBitsUint(Code, 20, 5);
            set => Code = BitMaskHelpers.SetBitsUint(Code, 20, 5, (uint)value);
        }

        public int ImmediateValue
        {
            get
            {
                var imm40 = BitMaskHelpers.GetBitsUint(Code, 7, 5);
                var imm115 = BitMaskHelpers.GetBitsUint(Code, 25, 7);
                var result = (int)((imm115 << 5) + imm40);
                result = result << 20 >> 20;
                return result;
            }
            set => Code = BitMaskHelpers.SetBitsUint(BitMaskHelpers.SetBitsUint(Code, 7, 5, BitMaskHelpers.GetMask(5) & (uint)value), 25, 7, BitMaskHelpers.GetMask(7) & (uint)(value >> 5));
        }

        internal static InstructionRV32I_S Decode(uint code)
        {
            var i = new InstructionRV32I_S(code);
            switch (i.Function3)
            {
                case SbFunct3:
                case ShFunct3:
                case SwFunct3:
                    // perfectly fine function
                    break;
                default:
                    throw new NotSupportedException();
            }

            return i;
        }

        private static InstructionRV32I_S CreateInstruction(uint function3, RegisterAddressRV32I source1, RegisterAddressRV32I source2, int immediate)
        {
            var i = new InstructionRV32I_S(function3, source1, source2, immediate);
            return i;
        }

        public static InstructionRV32I_S SW(RegisterAddressRV32I source1, RegisterAddressRV32I source2, int offset) => CreateInstruction(SwFunct3, source1, source2, offset);

        public static InstructionRV32I_S SH(RegisterAddressRV32I source1, RegisterAddressRV32I source2, int offset) => CreateInstruction(ShFunct3, source1, source2, offset);

        public static InstructionRV32I_S SB(RegisterAddressRV32I source1, RegisterAddressRV32I source2, int offset) => CreateInstruction(SbFunct3, source1, source2, offset);

        internal void Execute(ExecutionStateRV32I executionState)
        {
            switch (Function3)
            {
                case SbFunct3:
                    executionState.WriteByte((uint)(executionState.GetRegisterValue(SourceRegister1) + ImmediateValue), (byte)executionState.GetRegisterValue(SourceRegister2));
                    break;
                case ShFunct3:
                    executionState.WriteUShort((uint)(executionState.GetRegisterValue(SourceRegister1) + ImmediateValue), (ushort)executionState.GetRegisterValue(SourceRegister2));
                    break;
                case SwFunct3:
                    executionState.WriteUInt((uint)(executionState.GetRegisterValue(SourceRegister1) + ImmediateValue), executionState.GetRegisterValue(SourceRegister2));
                    break;
                default:
                    throw new NotImplementedException();
            }

            executionState.PC += 4;
        }

        public override string ToString()
        {
            var args = $"{SourceRegister2.ToDisplayString()}, 0x{ImmediateValue:X}({SourceRegister1.ToDisplayString()})";
            var instruction = Function3 switch
            {
                SbFunct3 => $"sb",
                ShFunct3 => $"sh",
                SwFunct3 => $"sw",
                _ => throw new NotImplementedException(),
            };

            return $"{instruction} {args}";
        }

        internal static bool TryParseRemainder(string instruction, string s, out InstructionRV32I_S result)
        {
            result = default;
            Func<RegisterAddressRV32I, RegisterAddressRV32I, int, InstructionRV32I_S>? creator = instruction switch
            {
                "sb" => SB,
                "sh" => SH,
                "sw" => SW,
                _ => null,
            };

            if (creator is null)
            {
                return false;
            }

            var match = Regex.Match(s, @"\s*(?<source2>[^,]+), *(?<offset>[^(]+)\((?<source1>[^)]+)\)\s*");
            result = creator(match.Groups["source1"].Value.ParseRegister(), match.Groups["source2"].Value.ParseRegister(), (int)match.Groups["offset"].Value.ParseNumber());
            return true;
        }
    }
}
