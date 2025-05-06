using System.Collections.Generic;
using MauiToolkitsDemo.Models;

namespace MauiToolkitsDemo.Services;

public class OrderService
{
    private readonly List<Product> _orderItems = [];
    
    public void AddToOrder(Product product)
    {
        // Logic to add the product to the order
        // This could involve updating a database, sending a request to a server, etc.
        _orderItems.Add(product);
    }
}