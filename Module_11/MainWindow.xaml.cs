using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Module_11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string data = "database.txt";

        private IChangePhone consultant = new Consultant();
        private IChangeInfo manager = new Manager();

        private ObservableCollection<Client> clients = new();
        private ObservableCollection<Log> logs = new();

        private Client currentClient;

        private string MiddleName;
        private string FirstName;
        private string LastName;
        private string PhoneNumber;
        private string Passport;



        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show("Перед начало работы, выберите за кого войти в систему!");

            cbDepartment.Items.Add("Консультант");
            cbDepartment.Items.Add("Менеджер");
        }

        /// <summary>
        /// Обновление данных клиента
        /// </summary>
        private void ButtonRefresh(object sender, RoutedEventArgs e)
        {
            MiddleName = MiddleNameTB.Text;
            FirstName = FirstNameTB.Text;
            LastName = LastNameTB.Text;
            PhoneNumber = PhoneNumberTB.Text;
            Passport = PassportTB.Text;

            if (cbDepartment.SelectedIndex == 0) //Консультант
            {
                if (currentClient.PhoneNumber != PhoneNumber)
                {
                    consultant.ChangePhone(currentClient, PhoneNumber);
                    consultant.ChangeLog();
                }
            }

            if (cbDepartment.SelectedIndex == 1) // Менеджер
                manager.ChangeInfo(MiddleName, FirstName, LastName, PhoneNumber, Passport, currentClient);

            Save(clients);
            logs.Clear(); 
            LoadLogs(logs);
            ClientsList.Items.Refresh();
        }

        /// <summary>
        /// Добавление нового клиента
        /// </summary>
        private void ButtonAddClient(object sender, RoutedEventArgs e)
        {
            if (cbDepartment.SelectedIndex == 1)
            {
                MiddleName = MiddleNameTB.Text;
                FirstName = FirstNameTB.Text;
                LastName = LastNameTB.Text;
                PhoneNumber = PhoneNumberTB.Text;
                Passport = PassportTB.Text;

                manager.AddClient(MiddleName, FirstName, LastName, PhoneNumber, Passport);
                clients.Add(new(MiddleName, FirstName, LastName, PhoneNumber, Passport));
            }
            else
                MessageBox.Show("У Вас недостаточно прав!");
        }

        private void ClientsListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentClient = (Client)(sender as ListView).SelectedValue;

            if (currentClient != null)
            {
                if (cbDepartment.SelectedIndex == 0)
                    PassportTB.Text = "***";

                if (cbDepartment.SelectedIndex == 1)
                    PassportTB.Text = currentClient.Passport;
            }
        }

        /// <summary>
        /// Выбор департамента
        /// </summary>
        private void cbDepartmentSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clients.Clear();
            logs.Clear();
            PassportTB.Clear();

            LoadLogs(logs);
            LoadClients(clients);

            ClientsList.ItemsSource = clients;
            LogsList.ItemsSource = logs;
        }

        /// <summary>
        /// Загрузка логов
        /// </summary>
        private static void LoadLogs(ObservableCollection<Log> logs)
        {
            using (StreamReader srlogs = new("logs.txt", true))
            {
                string line;
                int i = 0;
                while ((line = srlogs.ReadLine()) != null)
                {
                    string[] item = line.Split('\t');
                    logs.Add(new Log(item[0], item[1], item[2], item[3]));
                    i++;
                }
            }
        }

        /// <summary>
        /// Загрузка клиентов
        /// </summary>
        private static void LoadClients(ObservableCollection<Client> client)
        {
            using (StreamReader srclient = new(data, true))
            {
                string line;
                int i = 0;

                while ((line = srclient.ReadLine()) != null)
                {
                    string[] item = line.Split(' ');
                    client.Add(new Client(item[0], item[1], item[2], item[3], item[4]));
                    i++;
                }
            }
        }

        /// <summary>
        /// Сохранение данных клиентов
        /// </summary>
        private static void Save(ObservableCollection<Client> clients)
        {
            File.Create(data).Close();
            using (StreamWriter sr = new(data))
            {
                foreach (var item in clients)
                {
                    sr.WriteLine("{0} {1} {2} {3} {4}",
                        item.MiddleName,
                        item.FirstName,
                        item.LastName,
                        item.PhoneNumber,
                        item.Passport);
                }
            }
        }
    }
}
