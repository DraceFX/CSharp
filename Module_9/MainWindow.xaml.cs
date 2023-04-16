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

namespace Module_9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void divide_Click(object sender, RoutedEventArgs e)
        {
            outputListBox.Items.Clear();

            string inputText = inputClient.Text;
            string[] words = inputText.Split(" ");

            foreach (var item in words)
                outputListBox.Items.Add(item);
        }

        private void reverse_Click(object sender, RoutedEventArgs e)
        {
            outputLabel.Content = "";

            string inputText = inputClientReverse.Text;
            string[] words = inputText.Split(" ");

            Array.Reverse(words);

            foreach (var item in words)
                outputLabel.Content += item + " ";
        }
    }
}
