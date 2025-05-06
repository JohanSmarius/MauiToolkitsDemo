using System.Collections.Generic;
using MauiToolkitsDemo.Models;

namespace MauiToolkitsDemo.Services;

public class OrderService
{
    private readonly List<OrderLine> _orderItems = [];
    
    public IEnumerable<OrderLine> OrderItems => _orderItems;
    
    public void AddToOrder(Product product)
    {
        _orderItems.Add(new OrderLine() 
        { 
            Product = product,
            Quantity = 1
        });;
    }
}