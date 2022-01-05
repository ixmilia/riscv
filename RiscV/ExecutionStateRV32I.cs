namespace RiscV
{
    public partial class ExecutionStateRV32I
    {
        public uint PC { get; internal set; }

        private uint[] _registers = new uint[32];

        public uint X0 => GetRegisterValue(RegisterAddressRV32I.R0);

        public uint X1
        {
            get => GetRegisterValue(RegisterAddressRV32I.R1);
            set => SetRegisterValue(RegisterAddressRV32I.R1, value);
        }

        public uint X2
        {
            get => GetRegisterValue(RegisterAddressRV32I.R2);
            set => SetRegisterValue(RegisterAddressRV32I.R2, value);
        }

        public uint X3
        {
            get => GetRegisterValue(RegisterAddressRV32I.R3);
            set => SetRegisterValue(RegisterAddressRV32I.R3, value);
        }

        public uint X4
        {
            get => GetRegisterValue(RegisterAddressRV32I.R4);
            set => SetRegisterValue(RegisterAddressRV32I.R4, value);
        }

        public uint X5
        {
            get => GetRegisterValue(RegisterAddressRV32I.R5);
            set => SetRegisterValue(RegisterAddressRV32I.R5, value);
        }

        public uint X6
        {
            get => GetRegisterValue(RegisterAddressRV32I.R6);
            set => SetRegisterValue(RegisterAddressRV32I.R6, value);
        }

        public uint X7
        {
            get => GetRegisterValue(RegisterAddressRV32I.R7);
            set => SetRegisterValue(RegisterAddressRV32I.R7, value);
        }

        public uint X8
        {
            get => GetRegisterValue(RegisterAddressRV32I.R8);
            set => SetRegisterValue(RegisterAddressRV32I.R8, value);
        }

        public uint X9
        {
            get => GetRegisterValue(RegisterAddressRV32I.R9);
            set => SetRegisterValue(RegisterAddressRV32I.R9, value);
        }

        public uint X10
        {
            get => GetRegisterValue(RegisterAddressRV32I.R10);
            set => SetRegisterValue(RegisterAddressRV32I.R10, value);
        }

        public uint X11
        {
            get => GetRegisterValue(RegisterAddressRV32I.R11);
            set => SetRegisterValue(RegisterAddressRV32I.R11, value);
        }

        public uint X12
        {
            get => GetRegisterValue(RegisterAddressRV32I.R12);
            set => SetRegisterValue(RegisterAddressRV32I.R12, value);
        }

        public uint X13
        {
            get => GetRegisterValue(RegisterAddressRV32I.R13);
            set => SetRegisterValue(RegisterAddressRV32I.R13, value);
        }

        public uint X14
        {
            get => GetRegisterValue(RegisterAddressRV32I.R14);
            set => SetRegisterValue(RegisterAddressRV32I.R14, value);
        }

        public uint X15
        {
            get => GetRegisterValue(RegisterAddressRV32I.R15);
            set => SetRegisterValue(RegisterAddressRV32I.R15, value);
        }

        public uint X16
        {
            get => GetRegisterValue(RegisterAddressRV32I.R16);
            set => SetRegisterValue(RegisterAddressRV32I.R16, value);
        }

        public uint X17
        {
            get => GetRegisterValue(RegisterAddressRV32I.R17);
            set => SetRegisterValue(RegisterAddressRV32I.R17, value);
        }

        public uint X18
        {
            get => GetRegisterValue(RegisterAddressRV32I.R18);
            set => SetRegisterValue(RegisterAddressRV32I.R18, value);
        }

        public uint X19
        {
            get => GetRegisterValue(RegisterAddressRV32I.R19);
            set => SetRegisterValue(RegisterAddressRV32I.R19, value);
        }

        public uint X20
        {
            get => GetRegisterValue(RegisterAddressRV32I.R20);
            set => SetRegisterValue(RegisterAddressRV32I.R20, value);
        }

        public uint X21
        {
            get => GetRegisterValue(RegisterAddressRV32I.R21);
            set => SetRegisterValue(RegisterAddressRV32I.R21, value);
        }

        public uint X22
        {
            get => GetRegisterValue(RegisterAddressRV32I.R22);
            set => SetRegisterValue(RegisterAddressRV32I.R22, value);
        }

        public uint X23
        {
            get => GetRegisterValue(RegisterAddressRV32I.R23);
            set => SetRegisterValue(RegisterAddressRV32I.R23, value);
        }

        public uint X24
        {
            get => GetRegisterValue(RegisterAddressRV32I.R24);
            set => SetRegisterValue(RegisterAddressRV32I.R24, value);
        }

        public uint X25
        {
            get => GetRegisterValue(RegisterAddressRV32I.R25);
            set => SetRegisterValue(RegisterAddressRV32I.R25, value);
        }

        public uint X26
        {
            get => GetRegisterValue(RegisterAddressRV32I.R26);
            set => SetRegisterValue(RegisterAddressRV32I.R26, value);
        }

        public uint X27
        {
            get => GetRegisterValue(RegisterAddressRV32I.R27);
            set => SetRegisterValue(RegisterAddressRV32I.R27, value);
        }

        public uint X28
        {
            get => GetRegisterValue(RegisterAddressRV32I.R28);
            set => SetRegisterValue(RegisterAddressRV32I.R28, value);
        }

        public uint X29
        {
            get => GetRegisterValue(RegisterAddressRV32I.R29);
            set => SetRegisterValue(RegisterAddressRV32I.R29, value);
        }

        public uint X30
        {
            get => GetRegisterValue(RegisterAddressRV32I.R30);
            set => SetRegisterValue(RegisterAddressRV32I.R30, value);
        }

        public uint X31
        {
            get => GetRegisterValue(RegisterAddressRV32I.R31);
            set => SetRegisterValue(RegisterAddressRV32I.R31, value);
        }

        public uint GetRegisterValue(RegisterAddressRV32I register)
        {
            var index = (int)register;
            return _registers[index];
        }

        public void SetRegisterValue(RegisterAddressRV32I register, uint value)
        {
            if (register == RegisterAddressRV32I.R0)
            {
                throw new NotSupportedException();
            }

            var index = (int)register;
            _registers[index] = value;
        }
    }
}
