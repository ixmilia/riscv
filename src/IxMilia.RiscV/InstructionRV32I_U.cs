namespace IxMilia.RiscV
{
    public struct InstructionRV32I_U : IInstructionRV32I
    {
        public const uint LuiOpCode = 0b0110111;
        public const uint AuiPCOpCode = 0b0010111;

        public uint Code { get; internal set; }

        private InstructionRV32I_U(uint code)
        {
            Code = code;
        }

        public InstructionRV32I_U(uint opcode, RegisterAddressRV32I destination, uint immediate)
        {
            Code = opcode;
            DestinationRegister = destination;
            ImmediateValue = immediate;
        }

        public RegisterAddressRV32I DestinationRegister
        {
            get => (RegisterAddressRV32I)BitMaskHelpers.GetBitsUint(Code, 7, 5);
            set => Code = BitMaskHelpers.SetBitsUint(Code, 7, 5, (uint)value);
        }

        public uint ImmediateValue
        {
            get => BitMaskHelpers.GetBitsUint(Code, 12, 20) << 12;
            set => Code = BitMaskHelpers.SetBitsUint(Code, 12, 20, value >> 12);
        }

        public static InstructionRV32I_U Decode(uint code)
        {
            var i = new InstructionRV32I_U(code);
            switch (((IInstructionRV32I)i).OpCode)
            {
                case LuiOpCode:
                case AuiPCOpCode:
                    // perfectly fine function
                    break;
                default:
                    throw new NotSupportedException();
            }

            return i;
        }

        private static InstructionRV32I_U CreateInstruction(uint opcode, RegisterAddressRV32I destination, uint immediate)
        {
            var i = new InstructionRV32I_U(opcode, destination, immediate);
            return i;
        }

        public static InstructionRV32I_U Lui(RegisterAddressRV32I destination, uint immediate) => CreateInstruction(LuiOpCode, destination, immediate);

        public static InstructionRV32I_U AuiPC(RegisterAddressRV32I destination, uint immediate) => CreateInstruction(AuiPCOpCode, destination, immediate);

        internal void Execute(ExecutionStateRV32I executionState)
        {
            switch (((IInstructionRV32I)this).OpCode)
            {
                case LuiOpCode:
                    executionState.SetRegisterValue(DestinationRegister, ImmediateValue);
                    break;
                case AuiPCOpCode:
                    executionState.SetRegisterValue(DestinationRegister, executionState.PC + ImmediateValue);
                    break;
                default:
                    throw new NotImplementedException();
            }

            executionState.PC += 4;
        }
    }
}
