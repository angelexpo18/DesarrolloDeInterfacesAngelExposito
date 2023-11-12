using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiApp1.ViewModel;

public partial class MainViewModel : ObservableObject
{
    IConnectivity connectivity;
    public MainViewModel(IConnectivity connectivity)
    {
        Items = new ObservableCollection<string>();
        this.connectivity = connectivity;
    }

    [ObservableProperty]
    ObservableCollection<string> items;

    [ObservableProperty]
    string text;

    [ICommand]
    async Task Add()
    {
        if (string.IsNullOrWhiteSpace(Text))
            return;

        if(connectivity.NetworkAccess != NetworkAccess.Internet)
                {
            await Shell.Current.DisplayAlert("Uh Oh!", "No Internet", "OK");
                    return;
                }

        Items.Add(Text);
        //add our item
        Text = string.Empty;
    }
    [ICommand]
    void Deletes(string s)
    {
        if (Items.Contains(s))
        {
            Items.Remove(s);
        }
    }
    [ICommand]
    async Task Tap(string s)
    {
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}?id={s}");
    }
}