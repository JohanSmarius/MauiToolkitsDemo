using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls;

namespace MauiToolkitsDemo.ViewModels;

public class BaseContentPage<TViewModel> : ContentPage where TViewModel : ObservableObject
{
    public TViewModel ViewModel { get; set; }

    public BaseContentPage(TViewModel viewModel)
    {
        base.BindingContext = viewModel;
    }
    
    protected new TViewModel BindingContext => (TViewModel)base.BindingContext;
}   
