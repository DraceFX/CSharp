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
using System.Windows.Shapes;

namespace Module_18
{
    /// <summary>
    /// Логика взаимодействия для AddAnimal.xaml
    /// </summary>
    public partial class AddNewAnimal : Window
    {
        public AddNewAnimal()
        {
            InitializeComponent();
        }

        public AddNewAnimal(Repository repos) : this()
        {
            cancelButton.Click += delegate { this.DialogResult = false; };
            addAnimalButton.Click += delegate
            {
                repos.Add(AnimalFactory.GetAnimal(typeTB.Text, animalTB.Text, sexTB.Text, Convert.ToSingle(weightTB.Text)));

                string animalSave = "Animals";
                var saveDbTxt = new SaveDBTxt(animalSave);
                DBWriter dbw = new DBWriter(saveDbTxt);
                dbw.Save(repos);

                this.DialogResult = true;
            };
        }

    }
}
