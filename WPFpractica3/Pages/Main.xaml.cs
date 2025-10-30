using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

using System.Collections.ObjectModel;
using WPFpractica3.Classes;
using System.IO;
using System.Text.Json;

namespace WPFpractica3.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {

        public Doctor CurrentDoctor { get; set; }

        public ObservableCollection<Pacient> Pacients { get; set; } = new(); 

        public Pacient SelectedPacient { get; set; }

        public Main(Doctor doctor)
        {
            InitializeComponent();
            CurrentDoctor = doctor;
            DataContext = this;

            LoadPacients();
        }
        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            LoadPacients();
        }

        private void LoadPacients()
        {
            string dir = "pacients";

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            Pacients.Clear(); 

            foreach (var file in Directory.GetFiles(dir, "*.json"))
            {
                try
                {
                    string json = File.ReadAllText(file);
                    var pacient = JsonSerializer.Deserialize<Pacient>(json);
                    if (pacient != null)
                        Pacients.Add(pacient);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке пациента из файла {file}: {ex.Message}");
                }
            }
        }

        private void GoToAddPacientButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPacient());
            
        }

        private void GoToReceptionButton_Click(object sender, RoutedEventArgs e)
        {
            if(PacientListView.SelectedItem is Pacient selected)
            {
                SelectedPacient = selected;
                NavigationService.Navigate(new Reseption(CurrentDoctor, selected, Pacients));
            }
        }

        private void GoToEditPacientButton_Click(object sender, RoutedEventArgs e)
        {
            if (PacientListView.SelectedItem is Pacient selected)
            {
                SelectedPacient = selected;
                NavigationService.Navigate(new RedactingPacient(selected, Pacients));
            }
            else {
                MessageBox.Show("Выберите пациента из списка");
            }
            
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
