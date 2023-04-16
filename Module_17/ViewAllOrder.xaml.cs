using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
using System.Configuration;

namespace Module_17
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class ViewAllOrder : Window
    {
        public ViewAllOrder()
        {
            InitializeComponent();
            var connectionStringBuilderOLEDB = new OleDbConnectionStringBuilder
                (ConfigurationManager.ConnectionStrings["OleDBConnection"].ConnectionString);

            OleDbConnection conOleDB = new OleDbConnection(connectionStringBuilderOLEDB.ConnectionString);
            DataTable dt = new DataTable();
            OleDbDataAdapter daOleDB = new OleDbDataAdapter();

            var oleDB = @"SELECT * FROM TableOrder ORDER BY id";
            daOleDB.SelectCommand = new OleDbCommand(oleDB, conOleDB);

            daOleDB.Fill(dt);
            gridViewUser.DataContext = dt.DefaultView;
        }
    }
}
