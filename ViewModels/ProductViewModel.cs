using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiToolkitsDemo.Models;
using MauiToolkitsDemo.Services;
using Microsoft.Maui.Controls;

namespace MauiToolkitsDemo.ViewModels;

[QueryProperty(nameof(Id), "id")]
public partial class ProductViewModel : ObservableObject
{
    private readonly ProductService _productService;
    private readonly OrderService _orderService;
    
    private Product _selectedProduct;
    
    [ObservableProperty] private int id;
    
    [ObservableProperty]
    private string _name;
    
    [ObservableProperty]
    private string _description;
    
    [ObservableProperty]
    private decimal _price;

    [ObservableProperty] private double _customerRating;

    partial void OnIdChanged(int value)
    {
        _selectedProduct = _productService.Products.SingleOrDefault(p => p.Id == id);
        if (_selectedProduct != null)
        {
            Name = _selectedProduct.Name;
            Description = _selectedProduct.Description;
            Price = _selectedProduct.Price;
            
            CustomerRating = new Random().NextDouble() * 5;
        }
    }
   
    public ProductViewModel(ProductService productService, OrderService orderService)
    {
        _productService = productService;
        _orderService = orderService;
    }
    
    [RelayCommand]
    private async Task PlaceOrderCommand()
    {
        _orderService.AddToOrder(_selectedProduct);
        
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        string text = "Added to order";
        ToastDuration duration = ToastDuration.Short;
        double fontSize = 14;

        var toast = Toast.Make(text, duration, fontSize);

        await toast.Show(cancellationTokenSource.Token);
        
        await Shell.Current.GoToAsync("..");
    }
   
}