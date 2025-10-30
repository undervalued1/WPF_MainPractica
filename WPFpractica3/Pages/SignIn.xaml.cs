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
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignIn : Page
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            var user = (Doctor)Resources["doctor"];

            string userId = txtId.Text;
            string userPassword = txtPassword.Text;
            string filePath = $"doctors\\{userId}.json";

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Неверный ID или пароль");
                return;
            }

            string strFromFile = File.ReadAllText(filePath);
            var userFromFile = JsonSerializer.Deserialize<Doctor>(strFromFile);

            if (userPassword == userFromFile.Password)
            { 
                
                NavigationService.Navigate(new Main(userFromFile));
            }
            else
            {
                MessageBox.Show("Не верный ID или пароль");
            }
        }

        private void ButtonGoRegistr_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }
    }
}
