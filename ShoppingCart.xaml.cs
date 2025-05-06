using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiToolkitsDemo.ViewModels;

namespace MauiToolkitsDemo;

public partial class ShoppingCart : ContentPage
{
    public ShoppingCart(ShoppingCartViewModel viewModel)
    {
        InitializeComponent();
        
        BindingContext = viewModel;
    }
}