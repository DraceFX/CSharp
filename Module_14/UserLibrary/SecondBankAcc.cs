namespace UserLibrary
{
    class SecondBankAcc: IBankAccs
    {
        public string BankAcc { get; set; }
        public string BankAccType { get; set; }
        public int INN { get; set; }
        public SecondBankAcc(string BankAcc, string BankAccType, int INN) 
        { 
            this.BankAcc = BankAcc;
            this.BankAccType = BankAccType;
            this.INN = INN;
        }
    }
}
