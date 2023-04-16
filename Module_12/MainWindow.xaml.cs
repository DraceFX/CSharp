using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Module_12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string data = "database.txt";

        ObservableCollection<User<string>> usersList = new();

        public MainWindow()
        {
            InitializeComponent();
            Load();

            foreach (var user in usersList)
            {
                ActiveUser.Items.Add(user.FIO);
                ToUserCB.Items.Add(user.FIO);
            }
        }
        /// <summary>
        /// Выбор пользователя
        /// </summary>
        private void ActiveUserSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LVDepos.Items.Clear();

            foreach (var user in usersList)
            {
                if (ActiveUser.SelectedItem == user.FIO)
                {
                    foreach (var bankAcc in user.BankAccs)
                    {
                        LVDepos.Items.Add(bankAcc);
                    }
                }
            }
        }
        /// <summary>
        /// Перевод между счетами пользователя
        /// </summary>
        private void TransferOtherDeposButton(object sender, RoutedEventArgs e)
        {
            int money = int.Parse(TopUpTB.Text);

            foreach (var user in usersList)
            {
                if (ActiveUser.SelectedItem != user.FIO)
                    continue;

                if (LVDepos.SelectedIndex == 0)
                {
                    user.BankAccs[0].INN += money;
                    user.BankAccs[1].INN -= money;
                }
                if (LVDepos.SelectedIndex == 1)
                {
                    user.BankAccs[1].INN += money;
                    user.BankAccs[0].INN -= money;
                }
            }
            Save();
            LVDepos.Items.Refresh();
        }
        /// <summary>
        /// Откыть новый счёт
        /// </summary>
        private void CreateBankAccountButton(object sender, RoutedEventArgs e)
        {
            Random r = new();
            foreach (var user in usersList)
            {
                var bankacc = new SecondBankAcc(r.Next(10_000, 99_999).ToString(), "Недепозитный", 0);
                if (ActiveUser.SelectedItem == user.FIO)
                    user.BankAccs.Add(bankacc);

                Save();
                ActiveUserSelectionChanged(null, null);
            }
        }
        /// <summary>
        /// Закрыть счёт
        /// </summary>
        private void DeleteBankAccountButton(object sender, RoutedEventArgs e)
        {
            foreach (var user in usersList)
                if (ActiveUser.SelectedItem == user.FIO)
                    user.BankAccs.Remove(user.BankAccs[LVDepos.SelectedIndex]);

            Save();
            ActiveUserSelectionChanged(null, null);
        }
        /// <summary>
        /// Сделать счёт Депозитным
        /// </summary>
        private void MakeDepositBankAccButton(object sender, RoutedEventArgs e)
        {
            foreach (var user in usersList)
            {
                if (ActiveUser.SelectedItem != user.FIO)
                    continue;
                if (user.BankAccs[LVDepos.SelectedIndex].BankAccType == "Депозитный")
                    continue;

                var bankacc = new FirstBankAcc(user.BankAccs[LVDepos.SelectedIndex].BankAcc, "Депозитный", user.BankAccs[LVDepos.SelectedIndex].INN);
                user.BankAccs[LVDepos.SelectedIndex] = bankacc;
            }
            Save();
            ActiveUserSelectionChanged(null, null);
        }
        /// <summary>
        /// Сделать счёт Недепозитными
        /// </summary>
        private void MakeNonDepositBankAccButton(object sender, RoutedEventArgs e)
        {
            foreach (var user in usersList)
            {
                if (ActiveUser.SelectedItem != user.FIO)
                    continue;
                if (user.BankAccs[LVDepos.SelectedIndex].BankAccType == "Недепозитный")
                    continue;

                var bankacc = new SecondBankAcc(user.BankAccs[LVDepos.SelectedIndex].BankAcc, "Недепозитный", user.BankAccs[LVDepos.SelectedIndex].INN);
                user.BankAccs[LVDepos.SelectedIndex] = bankacc;
            }
            Save();
            ActiveUserSelectionChanged(null, null);
        }
        /// <summary>
        /// Перевод другоме пользователю
        /// </summary>
        private void PayToUserButton(object sender, RoutedEventArgs e)
        {
            int money = int.Parse(PayToUserTB.Text);

            foreach (var user in usersList)
            {
                if (ActiveUser.SelectedItem == user.FIO)
                    user.BankAccs[LVDepos.SelectedIndex].INN -= money;
                foreach (var bank in user.BankAccs)
                {
                    if (ToUserCB.SelectedItem == user.FIO)
                    {
                        if (bank.BankAccType == "Депозитный")
                            bank.INN += money;
                    }
                }
            }
            Save();
            LVDepos.Items.Refresh();
        }
        /// <summary>
        /// Загрузка из файла
        /// </summary>
        private void Load()
        {
            using (StreamReader srclient = new(data, true))
            {
                string line;

                while ((line = srclient.ReadLine()) != null)
                {
                    string[] item = line.Split('\t');
                    int bankAcc = 0;
                    var bankAccList = new List<IBankAccs>();
                    while (item.Length > bankAcc * 3 + 1)
                    {
                        string bankacc = item[bankAcc * 3 + 1];
                        string bankaccType = item[bankAcc * 3 + 2];
                        int inn = int.Parse(item[bankAcc * 3 + 3]);
                        if (bankaccType == "Недепозитный")
                        {
                            bankAccList.Add(new SecondBankAcc(bankacc, bankaccType, inn));
                        }
                        else if (bankaccType == "Депозитный")
                        {
                            bankAccList.Add(new FirstBankAcc(bankacc, bankaccType, inn));
                        }
                        bankAcc++;
                    }
                    usersList.Add(new User<string>(item[0], bankAccList));
                }
            }
        }
        /// <summary>
        /// Сохранение в файл
        /// </summary>
        private void Save()
        {
            File.Create(data).Close();
            using (StreamWriter sr = new(data))
            {
                foreach (var user in usersList)
                {
                    sr.Write($"{user.FIO}");
                    foreach (var bankacc in user.BankAccs)
                    {
                        sr.Write("\t{0}\t{1}\t{2}",
                            bankacc.BankAcc,
                            bankacc.BankAccType,
                            bankacc.INN);
                    }
                    sr.Write('\n');
                }
            }
        }
    }
}
