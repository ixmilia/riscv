namespace IxMilia.RiscV
{
    public struct InstructionRV32I_R : IInstructionRV32I
    {
        public const uint OpCode = 0b0110011;

        public const uint AddFunct3 = 0b000;
        public const uint AddFunct7 = 0b0000000;

        public const uint SltFunct3 = 0b010;
        public const uint SltFunct7 = 0b0000000;

        public const uint SltuFunct3 = 0b011;
        public const uint SltuFunct7 = 0b0000000;

        public const uint AndFunct3 = 0b111;
        public const uint AndFunct7 = 0b0000000;

        public const uint OrFunct3 = 0b110;
        public const uint OrFunct7 = 0b0000000;

        public const uint XorFunct3 = 0b100;
        public const uint XorFunct7 = 0b0000000;

        public const uint SllFunct3 = 0b001;
        public const uint SllFunct7 = 0b0000000;

        public const uint SrlFunct3 = 0b101;
        public const uint SrlFunct7 = 0b0000000;

        public const uint SubFunct3 = 0b000;
        public const uint SubFunct7 = 0b0100000;

        public const uint SraFunct3 = 0b101;
        public const uint SraFunct7 = 0b0100000;

        public uint Code { get; internal set; }

        private InstructionRV32I_R(uint code)
        {
            Code = code;
        }

        public InstructionRV32I_R(RegisterAddressRV32I destination, uint function3, RegisterAddressRV32I source1, RegisterAddressRV32I source2, uint function7)
        {
            Code = OpCode;
            DestinationRegister = destination;
            Function3 = function3;
            SourceRegister1 = source1;
            SourceRegister2 = source2;
            Function7 = function7;
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

        public RegisterAddressRV32I SourceRegister2
        {
            get => (RegisterAddressRV32I)BitMaskHelpers.GetBitsUint(Code, 20, 5);
            set => Code = BitMaskHelpers.SetBitsUint(Code, 20, 5, (uint)value);
        }

        public uint Function7
        {
            get => BitMaskHelpers.GetBitsUint(Code, 25, 7);
            set => Code = BitMaskHelpers.SetBitsUint(Code, 25, 7, value);
        }

        public static InstructionRV32I_R Decode(uint code)
        {
            var i = new InstructionRV32I_R(code);
            switch (i.Function7, i.Function3)
            {
                case (AddFunct7, AddFunct3):
                case (SltFunct7, SltFunct3):
                case (SltuFunct7, SltuFunct3):
                case (AndFunct7, AndFunct3):
                case (OrFunct7, OrFunct3):
                case (XorFunct7, XorFunct3):
                case (SllFunct7, SllFunct3):
                case (SrlFunct7, SrlFunct3):
                case (SubFunct7, SubFunct3):
                case (SraFunct7, SraFunct3):
                    // perfectly fine function
                    break;
                default:
                    throw new NotSupportedException();
            }

            return i;
        }

        private static InstructionRV32I_R CreateInstruction(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2, uint funct3, uint funct7)
        {
            var i = new InstructionRV32I_R(destination, funct3, source1, source2, funct7);
            return i;
        }

        public static InstructionRV32I_R Add(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => CreateInstruction(destination, source1, source2, AddFunct3, AddFunct7);

        public static InstructionRV32I_R Slt(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => CreateInstruction(destination, source1, source2, SltFunct3, SltFunct7);

        public static InstructionRV32I_R Sltu(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => CreateInstruction(destination, source1, source2, SltuFunct3, SltuFunct7);

        public static InstructionRV32I_R And(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => CreateInstruction(destination, source1, source2, AndFunct3, AndFunct7);

        public static InstructionRV32I_R Or(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => CreateInstruction(destination, source1, source2, OrFunct3, OrFunct7);

        public static InstructionRV32I_R Xor(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => CreateInstruction(destination, source1, source2, XorFunct3, XorFunct7);

        public static InstructionRV32I_R Sll(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => CreateInstruction(destination, source1, source2, SllFunct3, SllFunct7);

        public static InstructionRV32I_R Srl(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => CreateInstruction(destination, source1, source2, SrlFunct3, SrlFunct7);

        public static InstructionRV32I_R Sub(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => CreateInstruction(destination, source1, source2, SubFunct3, SubFunct7);

        public static InstructionRV32I_R Sra(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2) => CreateInstruction(destination, source1, source2, SraFunct3, SraFunct7);

        internal void Execute(ExecutionStateRV32I executionState)
        {
            switch ((Function3, Function7))
            {
                case (AddFunct3, AddFunct7):
                    executionState.SetRegisterValue(DestinationRegister, executionState.GetRegisterValue(SourceRegister1) + executionState.GetRegisterValue(SourceRegister2));
                    break;
                case (SltFunct3, SltFunct7):
                    executionState.SetRegisterValue(DestinationRegister, (int)executionState.GetRegisterValue(SourceRegister1) < (int)executionState.GetRegisterValue(SourceRegister2) ? 1u : 0);
                    break;
                case (SltuFunct3, SltuFunct7):
                    executionState.SetRegisterValue(DestinationRegister, executionState.GetRegisterValue(SourceRegister1) < executionState.GetRegisterValue(SourceRegister2) ? 1u : 0);
                    break;
                case (AndFunct3, AndFunct7):
                    executionState.SetRegisterValue(DestinationRegister, executionState.GetRegisterValue(SourceRegister1) & executionState.GetRegisterValue(SourceRegister2));
                    break;
                case (OrFunct3, OrFunct7):
                    executionState.SetRegisterValue(DestinationRegister, executionState.GetRegisterValue(SourceRegister1) | executionState.GetRegisterValue(SourceRegister2));
                    break;
                case (XorFunct3, XorFunct7):
                    executionState.SetRegisterValue(DestinationRegister, executionState.GetRegisterValue(SourceRegister1) ^ executionState.GetRegisterValue(SourceRegister2));
                    break;
                case (SllFunct3, SllFunct7):
                    executionState.SetRegisterValue(DestinationRegister, executionState.GetRegisterValue(SourceRegister1) << (int)BitMaskHelpers.GetBitsUint(executionState.GetRegisterValue(SourceRegister2), 0, 5));
                    break;
                case (SrlFunct3, SrlFunct7):
                    executionState.SetRegisterValue(DestinationRegister, executionState.GetRegisterValue(SourceRegister1) >> (int)BitMaskHelpers.GetBitsUint(executionState.GetRegisterValue(SourceRegister2), 0, 5));
                    break;
                case (SubFunct3, SubFunct7):
                    executionState.SetRegisterValue(DestinationRegister, executionState.GetRegisterValue(SourceRegister1) - executionState.GetRegisterValue(SourceRegister2));
                    break;
                case (SraFunct3, SraFunct7):
                    executionState.SetRegisterValue(DestinationRegister, (uint)((int)executionState.GetRegisterValue(SourceRegister1) >> (int)BitMaskHelpers.GetBitsUint(executionState.GetRegisterValue(SourceRegister2), 0, 5)));
                    break;
                default:
                    throw new NotImplementedException();
            }

            executionState.PC += 4;
        }
    }
}
