﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_12
{
    class FirstBankAcc : IBankAccs
    {
        public string BankAcc { get; set; }
        public string BankAccType { get; set; }
        public int INN { get; set; }
        public FirstBankAcc(string BankAcc, string BankAccType, int INN)
        { 
            this.BankAcc = BankAcc;
            this.BankAccType = BankAccType;
            this.INN = INN;
        }
    }
}
