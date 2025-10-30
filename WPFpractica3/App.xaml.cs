using System.Configuration;
using System.Data;
using System.Windows;
using WPFpractica3.Styles.Colors.Themes;

namespace WPFpractica3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ThemeHelper.ApplySave();
        }
    }

}
