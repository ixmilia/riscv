using System.Text.RegularExpressions;

namespace IxMilia.RiscV
{
    public struct InstructionRV32I_I : IInstructionRV32I
    {
        public const uint JalrOpCode = 0b1100111;
        public const uint LogicalOpCode = 0b0010011;
        public const uint LoadOpCode = 0b0000011;

        public const uint JalrFunct3 = 0b000;
        public const uint LWFunct3 = 0b010;
        public const uint LHFunct3 = 0b001;
        public const uint LHUFunct3 = 0b101;
        public const uint LBFunct3 = 0b000;
        public const uint LBUFunct3 = 0b100;

        public const uint AddIFunct3 = 0b000;
        public const uint SltIFunct3 = 0b010;
        public const uint SltIUFunct3 = 0b011;
        public const uint AndIFunct3 = 0b111;
        public const uint OrIFunct3 = 0b110;
        public const uint XorIFunct3 = 0b100;
        public const uint SllIFunct3 = 0b001;
        public const uint SrlIFunct3 = 0b101;
        public const uint SraIFunct3 = 0b101;

        public uint Code { get; internal set; }

        private InstructionRV32I_I(uint code)
        {
            Code = code;
        }

        private InstructionRV32I_I(uint opCode, RegisterAddressRV32I destination, uint function3, RegisterAddressRV32I source1)
        {
            Code = opCode;
            DestinationRegister = destination;
            Function3 = function3;
            SourceRegister1 = source1;
        }

        public InstructionRV32I_I(uint opCode, RegisterAddressRV32I destination, uint function3, RegisterAddressRV32I source1, int immediateValue)
            : this(opCode, destination, function3, source1)
        {
            ImmediateValue = immediateValue;
        }

        public InstructionRV32I_I(uint opCode, RegisterAddressRV32I destination, uint function3, RegisterAddressRV32I source1, uint immediateValue)
            : this(opCode, destination, function3, source1)
        {
            ImmediateValueUnsigned = immediateValue;
        }

        public RegisterAddressRV32I DestinationRegister
        {
            get => (RegisterAddressRV32I)BitMaskHelpers.GetBitsUint(Code, 7, 5);
            set => Code = BitMaskHelpers.SetBitsUint(Code, 7, 5, (uint)value);
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

        public int ImmediateValue
        {
            get => (int)BitMaskHelpers.GetBitsUint(Code, 20, 12) << 20 >> 20; // ensure sign extension
            set => Code = BitMaskHelpers.SetBitsUint(Code, 20, 12, (uint)value);
        }

        public uint ImmediateValueUnsigned
        {
            get => BitMaskHelpers.GetBitsUint(Code, 20, 12);
            set => Code = BitMaskHelpers.SetBitsUint(Code, 20, 12, value);
        }

        internal static InstructionRV32I_I Decode(uint code)
        {
            var i = new InstructionRV32I_I(code);
            switch (((IInstructionRV32I)i).OpCode, i.Function3)
            {
                case (JalrOpCode, JalrFunct3):
                case (LoadOpCode, LWFunct3):
                case (LoadOpCode, LHFunct3):
                case (LoadOpCode, LHUFunct3):
                case (LoadOpCode, LBFunct3):
                case (LoadOpCode, LBUFunct3):
                case (LogicalOpCode, AddIFunct3):
                case (LogicalOpCode, SltIFunct3):
                case (LogicalOpCode, SltIUFunct3):
                case (LogicalOpCode, AndIFunct3):
                case (LogicalOpCode, OrIFunct3):
                case (LogicalOpCode, XorIFunct3):
                case (LogicalOpCode, SllIFunct3):
                case (LogicalOpCode, SrlIFunct3):
                    //case SraIFunct3:
                    // perfectly fine function
                    break;
                default:
                    throw new NotSupportedException();
            }

            return i;
        }

        private static InstructionRV32I_I CreateInstruction(uint opCode, RegisterAddressRV32I destination, RegisterAddressRV32I source1, uint funct3, int immediateValue)
        {
            var i = new InstructionRV32I_I(opCode, destination, funct3, source1, immediateValue);
            return i;
        }

        private static InstructionRV32I_I CreateInstruction(uint opCode, RegisterAddressRV32I destination, RegisterAddressRV32I source1, uint funct3, uint immediateValue)
        {
            var i = new InstructionRV32I_I(opCode, destination, funct3, source1, immediateValue);
            return i;
        }

        public static InstructionRV32I_I Jalr(RegisterAddressRV32I destination, RegisterAddressRV32I source, int offset) => CreateInstruction(JalrOpCode, destination, source, JalrFunct3, offset);

        public static InstructionRV32I_I LW(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int address) => CreateInstruction(LoadOpCode, destination, source1, LWFunct3, address);

        public static InstructionRV32I_I LH(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int address) => CreateInstruction(LoadOpCode, destination, source1, LHFunct3, address);

        public static InstructionRV32I_I LHU(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int address) => CreateInstruction(LoadOpCode, destination, source1, LHUFunct3, address);

        public static InstructionRV32I_I LB(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int address) => CreateInstruction(LoadOpCode, destination, source1, LBFunct3, address);

        public static InstructionRV32I_I LBU(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int address) => CreateInstruction(LoadOpCode, destination, source1, LBUFunct3, address);

        public static InstructionRV32I_I AddI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int immediateValue) => CreateInstruction(LogicalOpCode, destination, source1, AddIFunct3, immediateValue);

        public static InstructionRV32I_I SltI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int immediateValue) => CreateInstruction(LogicalOpCode, destination, source1, SltIFunct3, immediateValue);

        public static InstructionRV32I_I SltIU(RegisterAddressRV32I destination, RegisterAddressRV32I source1, uint immediateValue) => CreateInstruction(LogicalOpCode, destination, source1, SltIUFunct3, immediateValue);

        public static InstructionRV32I_I AndI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int immediateValue) => CreateInstruction(LogicalOpCode, destination, source1, AndIFunct3, immediateValue);

        public static InstructionRV32I_I OrI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int immediateValue) => CreateInstruction(LogicalOpCode, destination, source1, OrIFunct3, immediateValue);

        public static InstructionRV32I_I XorI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int immediateValue) => CreateInstruction(LogicalOpCode, destination, source1, XorIFunct3, immediateValue);

        public static InstructionRV32I_I Not(RegisterAddressRV32I destination, RegisterAddressRV32I source1) => CreateInstruction(LogicalOpCode, destination, source1, XorIFunct3, BitMaskHelpers.GetMask(32));

        public static InstructionRV32I_I SllI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, uint shiftAmount) => CreateInstruction(LogicalOpCode, destination, source1, SllIFunct3, BitMaskHelpers.GetBitsUint(shiftAmount, 0, 5));

        public static InstructionRV32I_I SrlI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, uint shiftAmount) => CreateInstruction(LogicalOpCode, destination, source1, SrlIFunct3, BitMaskHelpers.GetBitsUint(shiftAmount, 0, 5));

        public static InstructionRV32I_I SraI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, uint shiftAmount) => CreateInstruction(LogicalOpCode, destination, source1, SraIFunct3, BitMaskHelpers.GetBitsUint(shiftAmount, 0, 5) | 0b010000000000);

        public static InstructionRV32I_I Nop() => CreateInstruction(LogicalOpCode, RegisterAddressRV32I.R0, RegisterAddressRV32I.R0, AddIFunct3, 0);

        internal void Execute(ExecutionStateRV32I executionState)
        {
            switch (((IInstructionRV32I)this).OpCode, Function3)
            {
                case (JalrOpCode, JalrFunct3):
                    executionState.SetRegisterValue(DestinationRegister, executionState.PC + 4);
                    executionState.PC = BitMaskHelpers.SetBitsUint((uint)((int)executionState.GetRegisterValue(SourceRegister1) + ImmediateValue), 0, 1, 0);
                    break;
                case (LoadOpCode, LWFunct3):
                    executionState.SetRegisterValue(DestinationRegister, executionState.ReadUInt((uint)((int)executionState.GetRegisterValue(SourceRegister1) + ImmediateValue)));
                    executionState.PC += 4;
                    break;
                case (LoadOpCode, LHFunct3):
                    executionState.SetRegisterValue(DestinationRegister, (uint)executionState.ReadUShort((uint)((int)executionState.GetRegisterValue(SourceRegister1) + ImmediateValue)) << 16 >> 16);
                    executionState.PC += 4;
                    break;
                case (LoadOpCode, LHUFunct3):
                    executionState.SetRegisterValue(DestinationRegister, executionState.ReadUShort((uint)((int)executionState.GetRegisterValue(SourceRegister1) + ImmediateValue)));
                    executionState.PC += 4;
                    break;
                case (LoadOpCode, LBFunct3):
                    executionState.SetRegisterValue(DestinationRegister, (uint)executionState.ReadByte((uint)((int)executionState.GetRegisterValue(SourceRegister1) + ImmediateValue)) << 24 >> 24);
                    executionState.PC += 4;
                    break;
                case (LoadOpCode, LBUFunct3):
                    executionState.SetRegisterValue(DestinationRegister, executionState.ReadByte((uint)((int)executionState.GetRegisterValue(SourceRegister1) + ImmediateValue)));
                    executionState.PC += 4;
                    break;
                case (LogicalOpCode, AddIFunct3):
                    executionState.SetRegisterValue(DestinationRegister, (uint)((int)executionState.GetRegisterValue(SourceRegister1) + ImmediateValue));
                    executionState.PC += 4;
                    break;
                case (LogicalOpCode, SltIFunct3):
                    executionState.SetRegisterValue(DestinationRegister, (int)executionState.GetRegisterValue(SourceRegister1) < ImmediateValue ? 1u : 0);
                    executionState.PC += 4;
                    break;
                case (LogicalOpCode, SltIUFunct3):
                    executionState.SetRegisterValue(DestinationRegister, executionState.GetRegisterValue(SourceRegister1) < ImmediateValueUnsigned ? 1u : 0);
                    executionState.PC += 4;
                    break;
                case (LogicalOpCode, AndIFunct3):
                    executionState.SetRegisterValue(DestinationRegister, (uint)((int)executionState.GetRegisterValue(SourceRegister1) & ImmediateValue));
                    executionState.PC += 4;
                    break;
                case (LogicalOpCode, OrIFunct3):
                    executionState.SetRegisterValue(DestinationRegister, (uint)((int)executionState.GetRegisterValue(SourceRegister1) | ImmediateValue));
                    executionState.PC += 4;
                    break;
                case (LogicalOpCode, XorIFunct3):
                    executionState.SetRegisterValue(DestinationRegister, (uint)((int)executionState.GetRegisterValue(SourceRegister1) ^ ImmediateValue));
                    executionState.PC += 4;
                    break;
                case (LogicalOpCode, SllIFunct3):
                    executionState.SetRegisterValue(DestinationRegister, executionState.GetRegisterValue(SourceRegister1) << ImmediateValue);
                    executionState.PC += 4;
                    break;
                case (LogicalOpCode, SrlIFunct3):
                    if (BitMaskHelpers.GetBitsUint(ImmediateValueUnsigned, 10, 1) == 0)
                    {
                        executionState.SetRegisterValue(DestinationRegister, executionState.GetRegisterValue(SourceRegister1) >> ImmediateValue);
                    }
                    else
                    {
                        executionState.SetRegisterValue(DestinationRegister, (uint)((int)executionState.GetRegisterValue(SourceRegister1) >> (int)BitMaskHelpers.GetBitsUint(ImmediateValueUnsigned, 0, 5)));
                    }

                    executionState.PC += 4;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public override string ToString()
        {
            return (((IInstructionRV32I)this).OpCode, Function3) switch
            {
                (JalrOpCode, JalrFunct3) => $"jalr {DestinationRegister.ToDisplayString()}, 0x{ImmediateValue:X}({SourceRegister1.ToDisplayString()})",
                (LoadOpCode, LWFunct3) => $"lw {DestinationRegister.ToDisplayString()}, 0x{ImmediateValue:X}({SourceRegister1.ToDisplayString()})",
                (LoadOpCode, LHFunct3) => $"lh {DestinationRegister.ToDisplayString()}, 0x{ImmediateValue:X}({SourceRegister1.ToDisplayString()})",
                (LoadOpCode, LHUFunct3) => $"lhu {DestinationRegister.ToDisplayString()}, 0x{ImmediateValue:X}({SourceRegister1.ToDisplayString()})",
                (LoadOpCode, LBFunct3) => $"lb {DestinationRegister.ToDisplayString()}, 0x{ImmediateValue:X}({SourceRegister1.ToDisplayString()})",
                (LoadOpCode, LBUFunct3) => $"lbu {DestinationRegister.ToDisplayString()}, 0x{ImmediateValue:X}({SourceRegister1.ToDisplayString()})",
                (LogicalOpCode, AddIFunct3) => $"addi {DestinationRegister.ToDisplayString()}, {SourceRegister1.ToDisplayString()}, 0x{ImmediateValue:X}",
                (LogicalOpCode, SltIFunct3) => $"slti {DestinationRegister.ToDisplayString()}, {SourceRegister1.ToDisplayString()}, 0x{ImmediateValue:X}",
                (LogicalOpCode, SltIUFunct3) => $"sltiu {DestinationRegister.ToDisplayString()}, {SourceRegister1.ToDisplayString()}, 0x{ImmediateValue:X}",
                (LogicalOpCode, AndIFunct3) => $"andi {DestinationRegister.ToDisplayString()}, {SourceRegister1.ToDisplayString()}, 0x{ImmediateValue:X}",
                (LogicalOpCode, OrIFunct3) => $"ori {DestinationRegister.ToDisplayString()}, {SourceRegister1.ToDisplayString()}, 0x{ImmediateValue:X}",
                (LogicalOpCode, XorIFunct3) => $"xori {DestinationRegister.ToDisplayString()}, {SourceRegister1.ToDisplayString()}, 0x{ImmediateValue:X}",
                (LogicalOpCode, SllIFunct3) => $"slli {DestinationRegister.ToDisplayString()}, {SourceRegister1.ToDisplayString()}, 0x{ImmediateValue:X}",
                (LogicalOpCode, SrlIFunct3) => $"srli {DestinationRegister.ToDisplayString()}, {SourceRegister1.ToDisplayString()}, 0x{ImmediateValue:X}",
                _ => throw new NotImplementedException(),
            };
        }

        private static Regex RegisterAndOffsetPattern = new Regex(@"\s*(?<destination>[^,]+), +(?<offset>[^(]+)\((?<source>[^)]+)\)\s*");
        private static Regex RegisterAndImmediatePattern = new Regex(@"\s*(?<destination>[^,]+), +(?<source>[^,]+), +(?<offset>.+)\s*");

        internal static bool TryParseRemainder(string instruction, string s, out InstructionRV32I_I result)
        {
            result = default;
            switch (instruction)
            {
                case "jalr":
                    {
                        var match = RegisterAndOffsetPattern.Match(s);
                        result = Jalr(match.Groups["destination"].Value.ParseRegister(), match.Groups["source"].Value.ParseRegister(), (int)match.Groups["offset"].Value.ParseNumber());
                        return true;
                    }
                case "lw":
                    {
                        var match = RegisterAndOffsetPattern.Match(s);
                        result = LW(match.Groups["destination"].Value.ParseRegister(), match.Groups["source"].Value.ParseRegister(), (int)match.Groups["offset"].Value.ParseNumber());
                        return true;
                    }
                case "lh":
                    {
                        var match = RegisterAndOffsetPattern.Match(s);
                        result = LH(match.Groups["destination"].Value.ParseRegister(), match.Groups["source"].Value.ParseRegister(), (int)match.Groups["offset"].Value.ParseNumber());
                        return true;
                    }
                case "lhu":
                    {
                        var match = RegisterAndOffsetPattern.Match(s);
                        result = LHU(match.Groups["destination"].Value.ParseRegister(), match.Groups["source"].Value.ParseRegister(), (int)match.Groups["offset"].Value.ParseNumber());
                        return true;
                    }
                case "lb":
                    {
                        var match = RegisterAndOffsetPattern.Match(s);
                        result = LB(match.Groups["destination"].Value.ParseRegister(), match.Groups["source"].Value.ParseRegister(), (int)match.Groups["offset"].Value.ParseNumber());
                        return true;
                    }
                case "lbu":
                    {
                        var match = RegisterAndOffsetPattern.Match(s);
                        result = LBU(match.Groups["destination"].Value.ParseRegister(), match.Groups["source"].Value.ParseRegister(), (int)match.Groups["offset"].Value.ParseNumber());
                        return true;
                    }
                case "addi":
                    {
                        var match = RegisterAndImmediatePattern.Match(s);
                        result = AddI(match.Groups["destination"].Value.ParseRegister(), match.Groups["source"].Value.ParseRegister(), (int)match.Groups["offset"].Value.ParseNumber());
                        return true;
                    }
                case "slti":
                    {
                        var match = RegisterAndImmediatePattern.Match(s);
                        result = SltI(match.Groups["destination"].Value.ParseRegister(), match.Groups["source"].Value.ParseRegister(), (int)match.Groups["offset"].Value.ParseNumber());
                        return true;
                    }
                case "sltiu":
                    {
                        var match = RegisterAndImmediatePattern.Match(s);
                        result = SltIU(match.Groups["destination"].Value.ParseRegister(), match.Groups["source"].Value.ParseRegister(), match.Groups["offset"].Value.ParseNumber());
                        return true;
                    }
                case "andi":
                    {
                        var match = RegisterAndImmediatePattern.Match(s);
                        result = AndI(match.Groups["destination"].Value.ParseRegister(), match.Groups["source"].Value.ParseRegister(), (int)match.Groups["offset"].Value.ParseNumber());
                        return true;
                    }
                case "ori":
                    {
                        var match = RegisterAndImmediatePattern.Match(s);
                        result = OrI(match.Groups["destination"].Value.ParseRegister(), match.Groups["source"].Value.ParseRegister(), (int)match.Groups["offset"].Value.ParseNumber());
                        return true;
                    }
                case "xori":
                    {
                        var match = RegisterAndImmediatePattern.Match(s);
                        result = XorI(match.Groups["destination"].Value.ParseRegister(), match.Groups["source"].Value.ParseRegister(), (int)match.Groups["offset"].Value.ParseNumber());
                        return true;
                    }
                case "slli":
                    {
                        var match = RegisterAndImmediatePattern.Match(s);
                        result = SllI(match.Groups["destination"].Value.ParseRegister(), match.Groups["source"].Value.ParseRegister(), match.Groups["offset"].Value.ParseNumber());
                        return true;
                    }
                case "srli":
                    {
                        var match = RegisterAndImmediatePattern.Match(s);
                        result = SrlI(match.Groups["destination"].Value.ParseRegister(), match.Groups["source"].Value.ParseRegister(), match.Groups["offset"].Value.ParseNumber());
                        return true;
                    }
                default:
                    return false;
            }
        }
    }
}
