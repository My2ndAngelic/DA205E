using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using BackendLibrary;

namespace A1MainAva
{
    public partial class MainWindow : Window
    {

        
        public MainWindow()
        {
            InitializeComponent();
            LoadCategories();
            LoadGenders();
        }
        
        private Animal tempAnimal = null;
        private IAnimalList animalList = new IAnimalList();
        private string? photoFile = string.Empty;

        



        private void LoadGenders()
        {
            ComboBoxGender.Items = Enum.GetValues(typeof(TGender)).Cast<TGender>();
            ComboBoxGender.SelectedIndex = 0;
        }

        private void LoadCategories()
        {
            ListBoxCat.Items = Enum.GetValues(typeof(TCategory)).Cast<TCategory>();
            ListBoxCat.SelectedIndex = 0;
        }

        private void LoadMammals()
        {
            ListBoxSpec.Items = Enum.GetValues(typeof(TMammal)).Cast<TMammal>();
            ListBoxSpec.SelectedIndex = 0;
        }

        private void LoadBirds()
        {
            ListBoxSpec.Items = Enum.GetValues(typeof(TBird)).Cast<TBird>();
            ListBoxSpec.SelectedIndex = 0;
        }


        private void ListBoxSpec_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            switch (ListBoxSpec.SelectedItem)
            {
                case TBird.Dove:
                    DebugText.Text = ListBoxSpec.SelectedItem.ToString();
                    tempAnimal = new SDove();
                    break;
                case TBird.Eagle:
                    DebugText.Text = ListBoxSpec.SelectedItem.ToString();
                    tempAnimal = new SEagle();
                    break;
                case TMammal.Cat:
                    DebugText.Text = ListBoxSpec.SelectedItem.ToString();
                    tempAnimal = new SCat();
                    break;
                case TMammal.Dog:
                    DebugText.Text = ListBoxSpec.SelectedItem.ToString();
                    tempAnimal = new SDog();
                    break;
            }
        }

        private void ListBoxCat_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            // ListBoxSpec.Items = ListBoxCat.SelectedItem switch
            // {
            //     TCategory.Bird => Enum.GetValues(typeof(TBird)).Cast<TBird>(),
            //     TCategory.Mammal => Enum.GetValues(typeof(TMammal)).Cast<TMammal>(),
            //     _ => ListBoxSpec.Items
            // };
            switch (ListBoxCat.SelectedItem)
            {
                case TCategory.Bird:
                    LoadBirds();
                    break;
                case TCategory.Mammal:
                    LoadMammals();
                    tempAnimal = new CMammal();
                    break;
            }
            ListBoxSpec.SelectedIndex = 0;
        }

        private void ButtonLoadPhoto_OnClick(object? sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                AllowMultiple = false
            };
            photoFile = ofd.ShowAsync(this).Result?[0];
            
        }
    }
}