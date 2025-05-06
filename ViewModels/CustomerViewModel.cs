using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiToolkitsDemo.ViewModels;

public partial class CustomerViewModel : ObservableValidator
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    [MinLength(3)]
    private string _firstName;
    
    [MinLength(5)]
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    private string _lastName;
    
    [ObservableProperty]
    private string _fullName;
}