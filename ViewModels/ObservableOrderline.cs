using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiToolkitsDemo.ViewModels;

public partial class ObservableOrderline : ObservableObject
{
    [ObservableProperty]
    private string productName;
    
    [ObservableProperty]
    private int quantity;
}