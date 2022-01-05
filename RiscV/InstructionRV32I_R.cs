namespace RiscV
{
    public struct InstructionRV32I_R : IInstructionRV32I
    {
        public const uint AddOpCode = 0b0110011;
        public const uint AddFunct3 = 0b000;
        public const uint AddFunct7 = 0b0000000;

        public const uint SubOpCode = AddOpCode;
        public const uint SubFunct3 = AddFunct3;
        public const uint SubFunct7 = 0b0100000;

        public uint Code { get; internal set; }

        public InstructionRV32I_R(uint opcode, RegisterAddressRV32I destination, uint function3, RegisterAddressRV32I source1, RegisterAddressRV32I source2, uint function7)
        {
            uint code = 0;
            code = BitMaskHelpers.SetBitsUint(code, 0, 7, opcode);
            code = BitMaskHelpers.SetBitsUint(code, 7, 5, (uint)destination);
            code = BitMaskHelpers.SetBitsUint(code, 12, 3, function3);
            code = BitMaskHelpers.SetBitsUint(code, 15, 5, (uint)source1);
            code = BitMaskHelpers.SetBitsUint(code, 20, 5, (uint)source2);
            code = BitMaskHelpers.SetBitsUint(code, 25, 7, function7);
            Code = code;
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

        public static InstructionRV32I_R Add(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2)
        {
            if (destination == RegisterAddressRV32I.R0)
            {
                throw new InvalidOperationException("R0 cannot be used as the destination");
            }

            var i = new InstructionRV32I_R(AddOpCode, destination, AddFunct3, source1, source2, AddFunct7);
            return i;
        }

        public static InstructionRV32I_R Sub(RegisterAddressRV32I destination, RegisterAddressRV32I source1, RegisterAddressRV32I source2)
        {
            if (destination == RegisterAddressRV32I.R0)
            {
                throw new InvalidOperationException("R0 cannot be used as the destination");
            }

            var i = new InstructionRV32I_R(SubOpCode, destination, SubFunct3, source1, source2, SubFunct7);
            return i;
        }

        internal void Execute(ExecutionStateRV32I executionState)
        {
            switch ((this.GetOpCode(), Function3, Function7))
            {
                case (AddOpCode, AddFunct3, AddFunct7):
                    executionState.SetRegisterValue(DestinationRegister, executionState.GetRegisterValue(SourceRegister1) + executionState.GetRegisterValue(SourceRegister2));
                    break;
                case (SubOpCode, SubFunct3, SubFunct7):
                    executionState.SetRegisterValue(DestinationRegister, executionState.GetRegisterValue(SourceRegister1) - executionState.GetRegisterValue(SourceRegister2));
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
