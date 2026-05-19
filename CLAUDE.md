# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

```bash
dotnet build          # compile
dotnet run            # build and launch the WPF window
```

There are no tests in this project yet.

## Architecture

This is a WPF app targeting .NET 7 (`net7.0-windows`) using **CommunityToolkit.Mvvm 8.4.2** for the MVVM pattern.

### Folder layout

```
Models/       — plain data classes, extend ObservableObject when the UI needs to react to property changes
ViewModels/   — one ViewModel per View; extend ObservableObject; use [ObservableProperty] and [RelayCommand]
Views/        — XAML windows and user controls; code-behind only sets DataContext, no logic
Themes/       — shared ResourceDictionary (Default.xaml) merged in App.xaml; put all styles/colors here
```

### Wiring

`App.xaml` has no `StartupUri`. Instead `App.xaml.cs::OnStartup` manually instantiates a ViewModel and passes it to the View constructor — this is the dependency injection seam. All new windows follow the same pattern: `new SomeWindow(new SomeViewModel())`.

### MVVM Toolkit conventions

- **`[ObservableProperty]`** on a private backing field generates the public property + `INotifyPropertyChanged` plumbing. The class must be `partial`.
- **`[RelayCommand]`** on a private method generates an `ICommand` property named `<Method>Command`. Pair with `CanExecute = nameof(...)` for button enable/disable.
- **`[NotifyCanExecuteChangedFor]`** on a property tells the toolkit to re-evaluate a command's `CanExecute` whenever that property changes.
- Models that need two-way UI binding also extend `ObservableObject` (see `TodoItem`).

### Styling

All brushes and control styles live in `Themes/Default.xaml`. Views reference styles by key (e.g. `Style="{StaticResource PrimaryButton}"`). Do not hardcode colors inline in XAML.

## Git workflow

After every change: commit with a clean message and `git push` to keep GitHub in sync.
