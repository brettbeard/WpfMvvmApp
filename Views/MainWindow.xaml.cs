using System.Windows;
using WpfMvvmApp.ViewModels;

namespace WpfMvvmApp.Views;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
