using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AddPacient.xaml
    /// </summary>
    public partial class AddPacient : Page
    {
        public AddPacient()
        {
            InitializeComponent();
        }

        private void NewPacientButton_Click(object sender, RoutedEventArgs e)
        {
            var pacient = (Pacient)Resources["pacient"];

            string key = RandomGenerateKeyForPacient();
            pacient.IdPacient = key;

            string filePath = $"pacients\\{key}.json";

            var strJson = JsonSerializer.Serialize(pacient);

            File.WriteAllText(filePath, strJson);
            NavigationService.GoBack();
        }

        private string RandomGenerateKeyForPacient()

        {
            Random random = new Random();
            string key;
            string pacientDirectory = "pacients";

            Directory.CreateDirectory(pacientDirectory);

            do
            {
                int number = random.Next(1000, 10000);
                key = $"P_{number}";
            }
            while (File.Exists(System.IO.Path.Combine(pacientDirectory, key + ".json")));

            return key;
        }
    }
}
