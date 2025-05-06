using System;
using System.Collections.ObjectModel;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;
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
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        var snackbarOptions = new SnackbarOptions
        {
            BackgroundColor = Colors.Wheat,
            TextColor = Colors.Black,
            ActionButtonTextColor = Colors.PaleVioletRed,
            CornerRadius = new CornerRadius(10),
            Font = Font.SystemFontOfSize(22),
            ActionButtonFont = Font.SystemFontOfSize(20),
            CharacterSpacing = 0.5
        };

        string text = "Order is placed. We wil ship it soon.";
        string actionButtonText = "You can click here";

        Action action = null;
        if (ActionForCallBack is not null)
        {
            action = ActionForCallBack;
        }

        TimeSpan duration = TimeSpan.FromSeconds(5);

        var snackbar = Snackbar.Make(text, duration: duration, visualOptions: snackbarOptions, action: action);

        await snackbar.Show(cancellationTokenSource.Token);
        
        
    }

    [RelayCommand]
    private async Task CustomerDetails()
    {
        await _popupService.ShowPopupAsync<CustomerViewModel>(onPresenting: viewModel => viewModel.FirstName = "Iris");
        
        
    }

}