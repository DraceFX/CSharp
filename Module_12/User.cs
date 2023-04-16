using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Module_12
{
    class User<T>
    {
        public T FIO { get; private set; }
        public List<IBankAccs> BankAccs { get; set; }

        public User(T FIO, List<IBankAccs> bankAccs)
        {
            this.FIO = FIO;
            this.BankAccs = bankAccs;
        }
    }
}
