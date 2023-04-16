using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Configuration;

namespace Module_16
{
    /// <summary>
    /// Логика взаимодействия для ViewAllOrder.xaml
    /// </summary>
    public partial class ViewAllOrder : Window
    {
        public ViewAllOrder()
        {
            InitializeComponent();
            var connectionStringBuilderOLEDB = new OleDbConnectionStringBuilder
                (ConfigurationManager.ConnectionStrings["OleDBConnection"].ConnectionString);

            OleDbConnection conOleDB = new(connectionStringBuilderOLEDB.ConnectionString);
            DataTable dt = new();
            OleDbDataAdapter daOleDB = new();

            var oleDB = @"SELECT * FROM TableOrder ORDER BY id";
            daOleDB.SelectCommand = new(oleDB, conOleDB);

            daOleDB.Fill(dt);
            gridViewUser.DataContext = dt.DefaultView;
        }
    }
}
