namespace IxMilia.RiscV
{
    public struct InstructionRV32I_J : IInstructionRV32I
    {
        public const uint JalOpCode = 0b1101111;

        public uint Code { get; internal set; }

        private InstructionRV32I_J(uint code)
        {
            Code = code;
        }

        public InstructionRV32I_J(uint opCode, RegisterAddressRV32I destination, int addressOffset)
        {
            Code = opCode;
            DestinationRegister = destination;
            AddressOffset = addressOffset;
        }

        public RegisterAddressRV32I DestinationRegister
        {
            get => (RegisterAddressRV32I)BitMaskHelpers.GetBitsUint(Code, 7, 5);
            set => Code = BitMaskHelpers.SetBitsUint(Code, 7, 5, (uint)value);
        }

        public int AddressOffset
        {
            get
            {
                var imm_10_1 = BitMaskHelpers.GetBitsUint(Code, 21, 10);
                var imm_11 = BitMaskHelpers.GetBitsUint(Code, 20, 1);
                var imm_19_12 = BitMaskHelpers.GetBitsUint(Code, 12, 8);
                var imm_20 = BitMaskHelpers.GetBitsUint(Code, 31, 1);
                var result = (int)((imm_20 << 20) + (imm_19_12 << 12) + (imm_11 << 11) + (imm_10_1 << 1));
                result = result << 11 >> 11;
                return result;
            }
            set
            {
                var v = (uint)((value << 11) >> 11);
                Code = BitMaskHelpers.SetBitsUint(Code, 21, 10, v >> 1);
                Code = BitMaskHelpers.SetBitsUint(Code, 20, 1, v >> 11);
                Code = BitMaskHelpers.SetBitsUint(Code, 12, 8, v >> 12);
                Code = BitMaskHelpers.SetBitsUint(Code, 31, 1, v >> 20);
            }
        }

        internal static InstructionRV32I_J Decode(uint code)
        {
            var i = new InstructionRV32I_J(code);
            switch (((IInstructionRV32I)i).OpCode)
            {
                case JalOpCode:
                    // perfectly fine function
                    break;
                default:
                    throw new NotSupportedException();
            }

            return i;
        }

        public static InstructionRV32I_J Jal(RegisterAddressRV32I destination, int addressOffset) => new InstructionRV32I_J(JalOpCode, destination, addressOffset);

        internal void Execute(ExecutionStateRV32I executionState)
        {
            switch (((IInstructionRV32I)this).OpCode)
            {
                case JalOpCode:
                    executionState.SetRegisterValue(DestinationRegister, executionState.PC + 4);
                    executionState.PC = (uint)(executionState.PC + AddressOffset);
                    break;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
