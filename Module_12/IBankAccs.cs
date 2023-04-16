using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_12
{
    interface IBankAccs
    {
        public string BankAcc { get; set; }
        public string BankAccType { get; set; }
        public int INN { get; set; }
    }
}
