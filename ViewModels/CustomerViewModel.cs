using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiToolkitsDemo.ViewModels;

public partial class CustomerViewModel : ObservableObject
{
    [ObservableProperty]
    private string _firstName;
    
    [ObservableProperty]
    private string _lastName;
}