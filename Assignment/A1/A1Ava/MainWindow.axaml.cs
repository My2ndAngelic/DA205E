using System;
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
        private readonly IAnimalList animalList = new IAnimalList();
        private string? photoFile = string.Empty;

        private Animal? tempAnimal;

        public MainWindow()
        {
            InitializeComponent();
            LoadCategories();
            LoadGenders();
        }

        /// <summary>
        ///     Load the photo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLoadPhoto_OnClick(object? sender, RoutedEventArgs e)
        {
            if ((photoFile = new OpenFileDialog {AllowMultiple = false}.ShowAsync(this).Result?[0]) is null)
                return; // If user cancelled the dialog because DialogResult.OK simply does not exist.
            try // Try reading the file
            {
                Stream stream = new FileStream(photoFile, FileMode.Open, FileAccess.Read,
                    FileShare.Read);
                Bitmap image = new Bitmap(stream);
                ImageAnimal.Source = image;
            }
            catch (ArgumentException) // Fail to load image
            {
                MessageBoxManager.GetMessageBoxStandardWindow(
                    new MessageBoxStandardParams // Package required: MesssageBox.Avalonia
                    {
                        ButtonDefinitions = ButtonEnum.Ok,
                        ContentTitle = "Error",
                        ContentMessage = "Fail to display image.",
                        WindowIcon = Icon,
                        Icon = MessageBox.Avalonia.Enums.Icon.Error
                    }).Show();
            }
        }


        /// <summary>
        ///     Click to save animal, show error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveAnimal_OnClick(object? sender, RoutedEventArgs e)
        {
            try
            {
                tempAnimal = ListBoxSpec.SelectedItem switch
                {
                    TBird.Dove => new SDove
                    {
                        Name = TextBoxName.Text,
                        Age = int.Parse(TextBoxAge.Text),
                        Gender = (TGender) ComboBoxGender.SelectedItem!,
                        CatData = int.Parse(TextBoxCatData.Text),
                        SpecData = int.Parse(TextBoxSpecData.Text)
                    },
                    TBird.Eagle => new SEagle
                    {
                        Name = TextBoxName.Text,
                        Age = int.Parse(TextBoxAge.Text),
                        Gender = (TGender) ComboBoxGender.SelectedItem!,
                        CatData = int.Parse(TextBoxCatData.Text),
                        SpecData = int.Parse(TextBoxSpecData.Text)
                    },
                    TMammal.Cat => new SCat
                    {
                        Name = TextBoxName.Text,
                        Age = int.Parse(TextBoxAge.Text),
                        Gender = (TGender) ComboBoxGender.SelectedItem!,
                        CatData = int.Parse(TextBoxCatData.Text),
                        SpecData = int.Parse(TextBoxSpecData.Text)
                    },
                    TMammal.Dog => new SDog
                    {
                        Name = TextBoxName.Text,
                        Age = int.Parse(TextBoxAge.Text),
                        Gender = (TGender) ComboBoxGender.SelectedItem!,
                        CatData = int.Parse(TextBoxCatData.Text),
                        SpecData = int.Parse(TextBoxSpecData.Text)
                    },
                    _ => tempAnimal
                };
                animalList.Add(tempAnimal);
                tempAnimal = null;
                DebugText.Text = animalList.ToStringAnimal(animalList.Last());
                ListBoxAnimal.Items = animalList.ToListString();
                ClearTextBox();
            }
            catch (Exception)
            {
                MessageBoxManager.GetMessageBoxStandardWindow(
                    new MessageBoxStandardParams // Package required: MesssageBox.Avalonia
                    {
                        ButtonDefinitions = ButtonEnum.Ok,
                        ContentTitle = "Error",
                        ContentMessage = "Fail to save animal. Please check the input.",
                        WindowIcon = Icon,
                        Icon = MessageBox.Avalonia.Enums.Icon.Error
                    }).Show();
            }
        }

        /// <summary>
        ///     Clear everything
        /// </summary>
        private void ClearTextBox()
        {
            TextBoxName.Text = string.Empty;
            TextBoxAge.Text = string.Empty;
            ComboBoxGender.SelectedIndex = 0;
            TextBoxCatData.Text = string.Empty;
            TextBoxSpecData.Text = string.Empty;
        }

        /// <summary>
        ///     Return all species list when clicked, also disable the other list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxAnimals_OnClick(object? sender, RoutedEventArgs e)
        {
            if ((bool) !CheckBoxAnimals.IsChecked)
            {
                ListBoxCat.IsEnabled = true;
                ListBoxCat.SelectedIndex = 0;
                return;
            }

            ListBoxCat.IsEnabled = false;
            ListBoxCat.SelectedIndex = -1;
            ListBoxSpec.Items = new List<Enum>(Enum.GetValues(typeof(TBird)).Cast<Enum>())
                .Union(Enum.GetValues(typeof(TMammal)).Cast<Enum>()); // join 2 enums list together
        }

        /// <summary>
        ///     Define behavior when an animal is selected
        ///     TODO: Edit mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBoxAnimal_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            if (ListBoxAnimal.SelectedIndex < 0) return;
            DebugText.Text = animalList.ToStringAnimal(ListBoxAnimal.SelectedIndex);
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


        private void ListBoxSpec_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            switch (ListBoxSpec.SelectedItem)
            {
                case TBird.Dove:
                    tempAnimal = new SDove();
                    TextBlockCatData.Text = "Flying speed (km/h)";
                    TextBlockSpecData.Text = "Weight (kg)";
                    break;
                case TBird.Eagle:
                    tempAnimal = new SEagle();
                    TextBlockCatData.Text = "Flying speed (km/h)";
                    TextBlockSpecData.Text = "Feather length (cm)";
                    break;
                case TMammal.Cat:
                    tempAnimal = new SCat();
                    TextBlockCatData.Text = "Number of teeth";
                    TextBlockSpecData.Text = "Number of color";
                    break;
                case TMammal.Dog:
                    tempAnimal = new SDog();
                    TextBlockCatData.Text = "Number of teeth";
                    TextBlockSpecData.Text = "Tail length (cm)";
                    break;
            }
        }

        private void LoadBirds()
        {
            ListBoxSpec.Items = Enum.GetValues(typeof(TBird)).Cast<TBird>();
            ListBoxSpec.SelectedIndex = 0;
        }

        private void LoadCategories()
        {
            ListBoxCat.Items = Enum.GetValues(typeof(TCategory)).Cast<TCategory>();
            ListBoxCat.SelectedIndex = 0;
        }

        private void LoadGenders()
        {
            ComboBoxGender.Items = Enum.GetValues(typeof(TGender)).Cast<TGender>();
            ComboBoxGender.SelectedIndex = 0;
        }

        private void LoadMammals()
        {
            ListBoxSpec.Items = Enum.GetValues(typeof(TMammal)).Cast<TMammal>();
            ListBoxSpec.SelectedIndex = 0;
        }

        private void MenuItem_OnClick(object? sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}