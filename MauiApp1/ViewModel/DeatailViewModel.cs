using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace MauiApp1.ViewModel;

[QueryProperty("Text", "Text")]
public partial class DeatailViewModel : ObservableObject
    {
    [ObservableProperty]
    string text;

    [ICommand]

    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
    }

