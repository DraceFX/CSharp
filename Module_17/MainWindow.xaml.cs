using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.Entity;

namespace Module_17
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataRowView row;
        MSSQLLocalModule_16Entities context;

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
            context = new MSSQLLocalModule_16Entities();

            context.TableUser.Load();
            gridView.ItemsSource = context.TableUser.Local.ToBindingList<TableUser>();
        }
        private void GVCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            row = (DataRowView)gridView.SelectedItem;
            row.BeginEdit();
            context.SaveChanges();
        }
        private void GVCurrentCellChanged(object sender, EventArgs e)
        {
            if (row == null) return;
            context.SaveChanges();
        }
        /// <summary>
        /// Окно добавление пользователя
        /// </summary>
        private void MenuItemAddClick(object sender, RoutedEventArgs e)
        {
            TableUser tu = new TableUser();
            AddNewUser add = new AddNewUser(tu);
            add.ShowDialog();

            if (add.DialogResult.Value)
            {
                context.TableUser.Add(tu);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        private void MenuItemDeleteClick(object sender, RoutedEventArgs e)
        {
            var selectUser = gridView.SelectedItem as TableUser;
            context.TableUser.Remove(selectUser);
            context.SaveChanges();
        }
        /// <summary>
        /// Окно показа всех заказов
        /// </summary>
        private void MenuItemShowOrderClick(object sender, RoutedEventArgs e) => new ViewAllOrder().ShowDialog();
    }
}
