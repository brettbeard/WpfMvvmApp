using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfMvvmApp.Models;

public partial class TodoItem : ObservableObject
{
    [ObservableProperty]
    private string title = string.Empty;

    [ObservableProperty]
    private bool isCompleted;
}
