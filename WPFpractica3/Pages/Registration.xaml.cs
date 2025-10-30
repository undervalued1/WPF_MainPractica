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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        
        public Registration()
        {
            InitializeComponent();
            
        }

        private void ButtonGoEnter_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ButtonRegistr_Click(object sender, RoutedEventArgs e)
        {
            var doctor = (Doctor)Resources["doctor"];
            string key = RandomGenerateKey();

            string filePath = $"doctors\\{key}.json";

            var strJson = JsonSerializer.Serialize(doctor);

            File.WriteAllText(filePath, strJson);

            MessageBox.Show($"Вы успешно зарегистрировались ваш идентификатор:{key}");
            NavigationService.GoBack();
        }

        private string RandomGenerateKey()
        {
            Random random = new Random();
            string key;
            string userDirectory = "doctors";

            Directory.CreateDirectory(userDirectory);

            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;

            do
            {
                int number = random.Next(10000, 100000);
                key = $"D_{number}";
            }
            while (File.Exists(System.IO.Path.Combine(projectDirectory, key + ".json")));

            return key;
        }
    }
}
