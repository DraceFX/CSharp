using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Module_17
{
    /// <summary>
    /// Логика взаимодействия для AddNewUser.xaml
    /// </summary>
    public partial class AddNewUser : Window
    {
        public AddNewUser()
        {
            InitializeComponent();
        }
        public AddNewUser(TableUser tu) : this()
        {
            cancelButton.Click += delegate { this.DialogResult = false; };
            addUserButton.Click += delegate
            {
                tu.secondName = secondNameTB.Text;
                tu.firstName = firstNameTB.Text;
                tu.lastName = lastNameTB.Text;
                tu.phoneNumber = phoneNumberTB.Text;
                tu.email = emailTB.Text;
                this.DialogResult = true;
            };
        }
    }
}
