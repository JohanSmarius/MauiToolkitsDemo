using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiToolkitsDemo.Models;
using MauiToolkitsDemo.Services;

namespace MauiToolkitsDemo.ViewModels;

public partial class ShoppingCartViewModel : ObservableObject
{
    private readonly OrderService _orderService;

    [ObservableProperty]
    private string _productName;

    [ObservableProperty]
    private decimal totalPrice;

    public ShoppingCartViewModel(OrderService orderService)
    {
        _orderService = orderService;
        
        foreach (var orderLine in _orderService.OrderItems)
        {
            var observableOrderLine = new ObservableOrderline()
            {
                ProductName = orderLine.Product.Name,
                Quantity = orderLine.Quantity
            };
            
            OrderLines.Add(observableOrderLine);
        }
    }

    public ObservableCollection<ObservableOrderline> OrderLines { get; } = [];


}