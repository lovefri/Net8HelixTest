using SfärProjekt.VieModels;
using SfärProjekt.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace SfärProjekt
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {


        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            MainViewModel mainViewModel = new MainViewModel();

            mainWindow.DataContext = mainViewModel;

            mainWindow.Show();
            base.OnStartup(e);
        }

    }

}


//Viewport3D viewPort3D = new Viewport3D();
//viewPort3D.DataContext = mainViewModel;