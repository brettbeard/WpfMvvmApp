using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace WpfMvvmApp.Models;

public partial class TodoItem : ObservableObject
{
    [ObservableProperty]
    private string title = string.Empty;

    [ObservableProperty]
    private bool isCompleted;

    public System.DateTime CreatedAt { get; set; }
}
