using System;
using System.Collections.ObjectModel;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.ApplicationModel;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiToolkitsDemo.Models;
using MauiToolkitsDemo.Services;
using Microsoft.Maui;
using Microsoft.Maui.Graphics;
using Font = Microsoft.Maui.Font;

namespace MauiToolkitsDemo.ViewModels;

public partial class ShoppingCartViewModel : ObservableObject
{
    private readonly OrderService _orderService;
    private readonly IPopupService _popupService;

    [ObservableProperty]
    private string _productName;

    [ObservableProperty]
    private decimal totalPrice;
    
    public Action ActionForCallBack { get; set; }

    public ShoppingCartViewModel(OrderService orderService, IPopupService popupService)
    {
        _orderService = orderService;
        _popupService = popupService;

        LoadOrders();
    }

    private void LoadOrders()
    {
        OrderLines.Clear();
        
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
    
    [RelayCommand]
    private async Task PlaceOrder()
    {
                
    }

    [RelayCommand]
    private async Task CustomerDetails()
    {
    }

}