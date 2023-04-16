using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Markup;
using System.Configuration;

namespace Module_16
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataTable dt;
        DataRowView row;

        public MainWindow()
        {
            InitializeComponent();
            Preparing();
        }
        /// <summary>
        /// Подготовка базы данных
        /// </summary>
        private void Preparing()
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder
                (ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);
            
            con = new(connectionStringBuilder.ConnectionString);
            dt = new DataTable();
            da = new();

            #region Select
            var sql = @"SELECT * FROM TableUser ORDER BY TableUser.id";
            da.SelectCommand = new SqlCommand(sql, con);
            #endregion

            SQLScripts sqlScripts = new();

            sqlScripts.SqlInsert(sql, da, con);
            sqlScripts.SqlUpdate(sql, da, con);
            sqlScripts.SqlDelete(sql, da, con);

            da.Fill(dt);
            gridView.DataContext = dt.DefaultView;
        }
        private void GVCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            row = (DataRowView)gridView.SelectedItem;
            row.BeginEdit();
            da.Update(dt);
        }
        private void GVCurrentCellChanged(object sender, EventArgs e)
        {
            if (row == null) return;
            row.EndEdit();
            da.Update(dt);
        }
        /// <summary>
        /// Окно добавление пользователя
        /// </summary>
        private void MenuItemAddClick(object sender, RoutedEventArgs e)
        {
            DataRow r = dt.NewRow();
            AddNewUser add = new(r);
            add.ShowDialog();

            if (add.DialogResult.Value)
            {
                dt.Rows.Add(r);
                da.Update(dt);
            }
        }
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        private void MenuItemDeleteClick(object sender, RoutedEventArgs e)
        {
            row = (DataRowView)gridView.SelectedItem;
            row.Row.Delete();
            da.Update(dt);
        }
        /// <summary>
        /// Окно показа всех заказов
        /// </summary>
        private void MenuItemShowOrderClick(object sender, RoutedEventArgs e) => new ViewAllOrder().ShowDialog();
    }
}
