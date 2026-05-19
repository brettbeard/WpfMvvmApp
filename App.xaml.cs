using System.Windows;
using WpfMvvmApp.ViewModels;
using WpfMvvmApp.Views;

namespace WpfMvvmApp;

public partial class App : Application
{
    private void OnStartup(object sender, StartupEventArgs e)
    {
        var viewModel = new MainViewModel();
        var window = new MainWindow(viewModel);
        window.Show();
    }
}

