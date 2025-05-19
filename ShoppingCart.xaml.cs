using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiToolkitsDemo.ViewModels;
using Microsoft.Maui.Controls;

namespace MauiToolkitsDemo;


public partial class ShoppingCart : ContentPage
{
    public ShoppingCart(ShoppingCartViewModel viewModel)
    {
        InitializeComponent();
        
        BindingContext = viewModel;
        
        viewModel.ActionForCallBack = () => DisplayAlert("Tapped on button", "The user has requested interaction", "OK");
    }
}