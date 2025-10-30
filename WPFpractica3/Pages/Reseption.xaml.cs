using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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

using WPFpractica3.Classes;

namespace WPFpractica3.Pages
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Reseption : Page
    {
        private Pacient _currentPacient;
        private ObservableCollection<Pacient> _pacients;
        private Doctor _currentDoctor;
        public Pacient CurrentPacient => _currentPacient;

        public Reseption(Doctor doctor ,Pacient pacientToReception, ObservableCollection<Pacient> _pacientsList)
        {
            InitializeComponent();
            _currentDoctor = doctor;
            _currentPacient = pacientToReception;
            _pacients = _pacientsList;

            DataContext = this;

            
            PacientHistoryListView.ItemsSource = _currentPacient.AppointmentStories;
        }

        private void AddReceptionButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DiagnosisTextBox.Text) ||
       string.IsNullOrWhiteSpace(RecommendationsTextBox.Text) ||
       ReceptionDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
                return;
            }

            var newAppointment = new AppointmentStory
            {
                DoctorId = _currentDoctor.IdDoctor,
                DoctorFullName = $"{_currentDoctor.LastName} {_currentDoctor.Name} {_currentDoctor.MiddleName}",
                Diagnosis = DiagnosisTextBox.Text,
                Recommendations = RecommendationsTextBox.Text,
                Date = ReceptionDatePicker.SelectedDate.Value
            };

            _currentPacient.AppointmentStories.Add(newAppointment);
            SavePacientData(_currentPacient);

            MessageBox.Show("Запись успешно добавлена!");
            PacientHistoryListView.Items.Refresh();

            DiagnosisTextBox.Clear();
            RecommendationsTextBox.Clear();
            ReceptionDatePicker.SelectedDate = DateTime.Now;
        }

        private void SavePacientData(Pacient pacient)
        {
            try
            {
                string dir = "pacients";
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                string filePath = System.IO.Path.Combine(dir, $"{pacient.IdPacient}.json");

                string json = JsonSerializer.Serialize(pacient, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
