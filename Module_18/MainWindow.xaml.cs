using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace Module_18
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository animals;
        Presenter present;
        public MainWindow()
        {
            InitializeComponent();
            Preparing();

            SaveBT.Click += (s, e) => present.SaveAnimals(); //Кнопка сохранения животных в docx и pdf формате
        }
        /// <summary>
        /// Подготовка таблицы
        /// </summary>
        private void Preparing()
        {
            animals = RepositoryFactory.GetRepositrory();

            #region обновление списка
            animals.animalsToList.Clear();
            grideView.Items.Clear();

            foreach (var item in animals.animalsToList)
                grideView.Items.Add(item);
            #endregion
        }
        /// <summary>
        /// Кнопка изменение параметров животного
        /// </summary>
        private void MenuChangeClick(object sender, RoutedEventArgs e)
        {
            if (grideView.SelectedItem == null) return;

            var animalChange = grideView.SelectedItem as IAnimal;
            ChangePropertyAnimal Change = new ChangePropertyAnimal(animalChange, animals);
            Change.ShowDialog();

            if (Change.DialogResult.Value)
            {
                animals.Delete(grideView.SelectedItem as IAnimal);
                present.SaveDataBase();
                Preparing();
            }
        }
        /// <summary>
        /// Удаление животного
        /// </summary>
        private void MenuDeleteClick(object sender, RoutedEventArgs e)
        {
            if (grideView.SelectedItem == null) return;

            animals.Delete(grideView.SelectedItem as IAnimal);
            present.SaveDataBase();
            Preparing();
        }
        /// <summary>
        /// Кнопка добавление нового животного
        /// </summary>
        private void AddAnimalButtonClick(object sender, RoutedEventArgs e)
        {
            AddNewAnimal add = new AddNewAnimal(animals);
            add.ShowDialog();

            if (add.DialogResult.Value)
                Preparing();
        }
    }
}
