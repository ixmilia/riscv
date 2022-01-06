namespace RiscV
{
    public struct InstructionRV32I_I : IInstructionRV32I
    {
        public const uint OpCode = 0b0010011;

        public const uint AddIFunct3 = 0b000;
        public const uint SltIFunct3 = 0b010;

        public uint Code { get; internal set; }

        private InstructionRV32I_I(uint code)
        {
            Code = code;
        }

        public InstructionRV32I_I(RegisterAddressRV32I destination, uint function3, RegisterAddressRV32I source1, int immediateValue)
        {
            Code = OpCode;
            DestinationRegister = destination;
            Function3 = function3;
            SourceRegister1 = source1;
            ImmediateValue = immediateValue;
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

        public static InstructionRV32I_I Decode(uint code)
        {
            var i = new InstructionRV32I_I(code);
            switch (i.Function3)
            {
                case AddIFunct3:
                case SltIFunct3:
                    // perfectly fine function
                    break;
                default:
                    throw new NotSupportedException();
            }

            return i;
        }

        private static InstructionRV32I_I CreateInstruction(RegisterAddressRV32I destination, RegisterAddressRV32I source1, uint funct3, int immediateValue)
        {
            if (destination == RegisterAddressRV32I.R0)
            {
                throw new InvalidOperationException("R0 cannot be used as the destination");
            }

            var i = new InstructionRV32I_I(destination, funct3, source1, immediateValue);
            return i;
        }

        public static InstructionRV32I_I AddI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int immediateValue) => CreateInstruction(destination, source1, AddIFunct3, immediateValue);

        public static InstructionRV32I_I SltI(RegisterAddressRV32I destination, RegisterAddressRV32I source1, int immediateValue) => CreateInstruction(destination, source1, SltIFunct3, immediateValue);

        internal void Execute(ExecutionStateRV32I executionState)
        {
            switch (Function3)
            {
                case AddIFunct3:
                    executionState.SetRegisterValue(DestinationRegister, (uint)((int)executionState.GetRegisterValue(SourceRegister1) + ImmediateValue));
                    break;
                case SltIFunct3:
                    executionState.SetRegisterValue(DestinationRegister, (int)executionState.GetRegisterValue(SourceRegister1) < ImmediateValue ? 1u : 0);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
