using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiToolkitsDemo.ViewModels;
using Microsoft.Maui.Controls;

namespace MauiToolkitsDemo;

public partial class ProductDetail : ContentPage
{
    public ProductDetail(ProductViewModel viewModel)
    {
        InitializeComponent();
        
        BindingContext = viewModel;
    }
}