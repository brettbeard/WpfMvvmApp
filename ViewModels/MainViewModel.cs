using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfMvvmApp.Models;

namespace WpfMvvmApp.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddTodoCommand))]
    private string newTodoTitle = string.Empty;

    [ObservableProperty]
    private int completedCount;

    [ObservableProperty]
    private int totalCount;

    public ObservableCollection<TodoItem> Todos { get; } = new();

    public MainViewModel()
    {
        Todos.CollectionChanged += (_, _) => RefreshCounts();
    }

    [RelayCommand(CanExecute = nameof(CanAddTodo))]
    private void AddTodo()
    {
        var item = new TodoItem { Title = NewTodoTitle.Trim() };
        item.PropertyChanged += (_, _) => RefreshCounts();
        Todos.Add(item);
        NewTodoTitle = string.Empty;
        RefreshCounts();
    }

    private bool CanAddTodo() => !string.IsNullOrWhiteSpace(NewTodoTitle);

    [RelayCommand]
    private void RemoveTodo(TodoItem todo)
    {
        Todos.Remove(todo);
        RefreshCounts();
    }

    [RelayCommand]
    private void ClearCompleted()
    {
        foreach (var item in Todos.Where(t => t.IsCompleted).ToList())
            Todos.Remove(item);
        RefreshCounts();
    }

    private void RefreshCounts()
    {
        TotalCount = Todos.Count;
        CompletedCount = Todos.Count(t => t.IsCompleted);
    }
}
