using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using BackendLibrary;
using MessageBox.Avalonia;
using MessageBox.Avalonia.DTO;
using MessageBox.Avalonia.Enums;

namespace A1Ava
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
                    tempAnimal = new SDove();
                    DebugText.Text = tempAnimal.ToString();

                    break;
                case TBird.Eagle:
                    tempAnimal = new SEagle();
                    DebugText.Text = tempAnimal.ToString();

                    break;
                case TMammal.Cat:
                    tempAnimal = new SCat();
                    DebugText.Text = tempAnimal.ToString();

                    break;
                case TMammal.Dog:
                    tempAnimal = new SDog();
                    DebugText.Text = tempAnimal.ToString();

                    break;
            }
        }

        private void ListBoxCat_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            ListBoxSpec.Items = ListBoxCat.SelectedItem switch
            {
                TCategory.Bird => Enum.GetValues(typeof(TBird)).Cast<TBird>(),
                TCategory.Mammal => Enum.GetValues(typeof(TMammal)).Cast<TMammal>(),
                _ => ListBoxSpec.Items
            };
            ListBoxSpec.SelectedIndex = 0;
        }

        private void ButtonLoadPhoto_OnClick(object? sender, RoutedEventArgs e)
        {
            if ((photoFile = new OpenFileDialog{AllowMultiple = false}.ShowAsync(this).Result?[0]) is null) return;
            try
            {
                Stream stream = new FileStream(path: photoFile, mode: FileMode.Open, access: FileAccess.Read,
                    share: FileShare.Read);
                Bitmap image = new Bitmap(stream);
                ImageAnimal.Source = image;
            }
            catch (ArgumentException) // Fail to load image
            {
                MessageBoxManager.GetMessageBoxStandardWindow(new MessageBoxStandardParams
                {
                    ButtonDefinitions = ButtonEnum.Ok,
                    ContentTitle = "Failed",
                    ContentMessage = "Fail to display image.",
                    WindowIcon = Icon,
                    Icon = MessageBox.Avalonia.Enums.Icon.Error,
                }).Show();
            }
        }

        private void MenuItem_OnClick(object? sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }


        private void ButtonSaveAnimal_OnClick(object? sender, RoutedEventArgs e)
        {
            
        }

        /// <summary>
        ///     Return all species list when clicked, also disable the other list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxAnimals_OnClick(object? sender, RoutedEventArgs e)
        {
            if (CheckBoxAnimals.IsChecked == false)
            {
                ListBoxCat.IsEnabled = true;
                ListBoxCat.SelectedIndex = 0;
                return;
            }

            ListBoxCat.IsEnabled = false;
            ListBoxCat.SelectedIndex = -1;
            ListBoxSpec.Items = new List<Enum>(Enum.GetValues(typeof(TBird)).Cast<Enum>())
                .Union(Enum.GetValues(typeof(TMammal)).Cast<Enum>());
        }
    }
}