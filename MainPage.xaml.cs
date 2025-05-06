using MauiToolkitsDemo.ViewModels;
using Microsoft.Maui.Accessibility;
using Microsoft.Maui.Controls;

namespace MauiToolkitsDemo;

public partial class MainPage : ContentPage
{
    public MainPage(ProductsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

}