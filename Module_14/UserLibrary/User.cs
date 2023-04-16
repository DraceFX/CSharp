using System;
using System.Windows;
using System.Collections.Generic;
using LogLibrary;

namespace UserLibrary
{
    public delegate void Hadler(string FIO, string Act);
    public class User<T>
    {
        public event Hadler ActionUser;
        public T FIO { get; private set; }
        public List<IBankAccs> BankAccs { get; set; }

        public User(T FIO, List<IBankAccs> bankAccs)
        {
            this.FIO = FIO;
            this.BankAccs = bankAccs;
        }
        public void ActionBankAcc(string FIO, string Act)
        {
            MessageBox.Show($"{FIO} {Act}");

            string time = DateTime.Now.ToString();
            Log logs = new(time, FIO, Act);
            logs.LogSave();
        }
    }
}
