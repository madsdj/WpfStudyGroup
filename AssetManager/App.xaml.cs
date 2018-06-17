using System.Windows;
using AssetManager.Views;

namespace AssetManager
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainView { DataContext = PureConfig.ResolveMainViewModel() };
            MainWindow.Show();
        }
    }
}
