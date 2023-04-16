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
    /// Логика взаимодействия для ChangePropertyAnimal.xaml
    /// </summary>
    public partial class ChangePropertyAnimal : Window
    {
        public ChangePropertyAnimal()
        {
            InitializeComponent();
        }
        public ChangePropertyAnimal(IAnimal animals, Repository repos) : this()
        {
            typeTB.Text = animals.Type;
            animalTB.Text = animals.Animal;
            sexTB.Text = animals.Sex;
            weightTB.Text = animals.Weight.ToString();

            cancelButton.Click += delegate { this.DialogResult = false; };
            changeAnimalButton.Click += delegate
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
