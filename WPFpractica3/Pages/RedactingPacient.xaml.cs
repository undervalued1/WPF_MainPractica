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
    /// Логика взаимодействия для RedactingPacient.xaml
    /// </summary>
    public partial class RedactingPacient : Page
    {
        private Pacient _originalPacient;
        private ObservableCollection<Pacient> _pacients;

        public RedactingPacient(Pacient pacientToEdit, ObservableCollection<Pacient> _pacientsList)
        {
            InitializeComponent();
            
            _originalPacient = pacientToEdit;
            _pacients = _pacientsList;
            
            

            var editablePacient = new Pacient
            {
                IdPacient = pacientToEdit.IdPacient,
                Name = pacientToEdit.Name,
                LastName = pacientToEdit.LastName,
                MiddleName = pacientToEdit.MiddleName,
                DateBirthday = pacientToEdit.DateBirthday,
                PhoneNumber = pacientToEdit.PhoneNumber
            };

            DataContext = editablePacient;
        }

        private void EditPacientButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is Pacient edited)
            {
                // Обновляем оригинал
                _originalPacient.Name = edited.Name;
                _originalPacient.LastName = edited.LastName;
                _originalPacient.MiddleName = edited.MiddleName;
                _originalPacient.DateBirthday = edited.DateBirthday;
                _originalPacient.PhoneNumber = edited.PhoneNumber;

                // Сохраняем в файл
                string filePath = $"pacients\\{_originalPacient.IdPacient}.json";
                string json = JsonSerializer.Serialize(_originalPacient, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);

                MessageBox.Show("Информация о пациенте успешно обновлена.");
                NavigationService.GoBack(); // Вернуться назад
            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
