using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiToolkitsDemo.ViewModels;

public partial class CustomerViewModel : ObservableValidator
{
    private readonly IPopupService _popupService;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    [MinLength(3)]
    private string _firstName;
    
    [MinLength(5)]
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FullName))]
    private string _lastName;

    [ObservableProperty]
    private string _email;
    
    public string FullName => $"{FirstName} {LastName}";

    public CustomerViewModel(IPopupService popupService)
    {
        _popupService = popupService;
    }
    
    [RelayCommand(CanExecute = nameof(CanSave))]
    private async Task Save()
    {
        
        
        await _popupService.ClosePopupAsync(FullName);

    }

    bool CanSave() => string.IsNullOrEmpty(FullName) is false;
}