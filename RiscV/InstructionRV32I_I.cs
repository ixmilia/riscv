namespace RiscV
{
    public struct InstructionRV32I_I : IInstructionRV32I
    {
        public const uint LogicalOpCode = 0b0010011;
        public const uint LoadOpCode = 0b0000011;

        public const uint LWFunct3 = 0b010;

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

        public static InstructionRV32I_I Decode(uint code)
        {
            var i = new InstructionRV32I_I(code);
            switch (((IInstructionRV32I)i).OpCode, i.Function3)
            {
                case (LoadOpCode, LWFunct3):
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
            if (destination == RegisterAddressRV32I.R0)
            {
                if (source1 == RegisterAddressRV32I.R0 && immediateValue == 0)
                {
                    // nop
                }
                else
                {
                    throw new InvalidOperationException("R0 cannot be used as the destination");
                }
            }

            var i = new InstructionRV32I_I(opCode, destination, funct3, source1, immediateValue);
            return i;
        }

        private static InstructionRV32I_I CreateInstruction(uint opCode, RegisterAddressRV32I destination, RegisterAddressRV32I source1, uint funct3, uint immediateValue)
        {
            if (destination == RegisterAddressRV32I.R0)
            {
                throw new InvalidOperationException("R0 cannot be used as the destination");
            }

            var i = new InstructionRV32I_I(opCode, destination, funct3, source1, immediateValue);
            return i;
        }

        public static InstructionRV32I_I LW(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int address) => CreateInstruction(LoadOpCode, destination, source1, LWFunct3, address);

        public static InstructionRV32I_I AddI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int immediateValue) => CreateInstruction(LogicalOpCode, destination, source1, AddIFunct3, immediateValue);

        public static InstructionRV32I_I SltI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int immediateValue) => CreateInstruction(LogicalOpCode, destination, source1, SltIFunct3, immediateValue);

        public static InstructionRV32I_I SltIU(RegisterAddressRV32I destination, RegisterAddressRV32I source1, uint immediateValue) => CreateInstruction(LogicalOpCode, destination, source1, SltIUFunct3, immediateValue);

        public static InstructionRV32I_I AndI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int immediateValue) => CreateInstruction(LogicalOpCode, destination, source1, AndIFunct3, immediateValue);

        public static InstructionRV32I_I OrI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int immediateValue) => CreateInstruction(LogicalOpCode, destination, source1, OrIFunct3, immediateValue);

        public static InstructionRV32I_I XorI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int immediateValue) => CreateInstruction(LogicalOpCode, destination, source1, XorIFunct3, immediateValue);

        public static InstructionRV32I_I SllI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, uint shiftAmount) => CreateInstruction(LogicalOpCode, destination, source1, SllIFunct3, BitMaskHelpers.GetBitsUint(shiftAmount, 0, 5));

        public static InstructionRV32I_I SrlI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, uint shiftAmount) => CreateInstruction(LogicalOpCode, destination, source1, SrlIFunct3, BitMaskHelpers.GetBitsUint(shiftAmount, 0, 5));

        public static InstructionRV32I_I SraI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, uint shiftAmount) => CreateInstruction(LogicalOpCode, destination, source1, SraIFunct3, BitMaskHelpers.GetBitsUint(shiftAmount, 0, 5) | 0b010000000000);

        public static InstructionRV32I_I Nop() => CreateInstruction(LogicalOpCode, RegisterAddressRV32I.R0, RegisterAddressRV32I.R0, AddIFunct3, 0);

        internal void Execute(ExecutionStateRV32I executionState)
        {
            switch (((IInstructionRV32I)this).OpCode, Function3)
            {
                case (LoadOpCode, LWFunct3):
                    executionState.SetRegisterValue(DestinationRegister, executionState.ReadUInt((uint)((int)executionState.GetRegisterValue(SourceRegister1) + ImmediateValue)));
                    break;
                case (LogicalOpCode, AddIFunct3):
                    if (DestinationRegister == RegisterAddressRV32I.R0 &&
                        SourceRegister1 == RegisterAddressRV32I.R0 &&
                        ImmediateValue == 0)
                    {
                        // nop
                    }
                    else
                    {
                        executionState.SetRegisterValue(DestinationRegister, (uint)((int)executionState.GetRegisterValue(SourceRegister1) + ImmediateValue));
                    }
                    break;
                case (LogicalOpCode, SltIFunct3):
                    executionState.SetRegisterValue(DestinationRegister, (int)executionState.GetRegisterValue(SourceRegister1) < ImmediateValue ? 1u : 0);
                    break;
                case (LogicalOpCode, SltIUFunct3):
                    executionState.SetRegisterValue(DestinationRegister, executionState.GetRegisterValue(SourceRegister1) < ImmediateValueUnsigned ? 1u : 0);
                    break;
                case (LogicalOpCode, AndIFunct3):
                    executionState.SetRegisterValue(DestinationRegister, (uint)((int)executionState.GetRegisterValue(SourceRegister1) & ImmediateValue));
                    break;
                case (LogicalOpCode, OrIFunct3):
                    executionState.SetRegisterValue(DestinationRegister, (uint)((int)executionState.GetRegisterValue(SourceRegister1) | ImmediateValue));
                    break;
                case (LogicalOpCode, XorIFunct3):
                    executionState.SetRegisterValue(DestinationRegister, (uint)((int)executionState.GetRegisterValue(SourceRegister1) ^ ImmediateValue));
                    break;
                case (LogicalOpCode, SllIFunct3):
                    executionState.SetRegisterValue(DestinationRegister, executionState.GetRegisterValue(SourceRegister1) << ImmediateValue);
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
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
