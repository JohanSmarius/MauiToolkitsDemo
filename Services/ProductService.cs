using System.Collections.Generic;
using MauiToolkitsDemo.Models;

namespace MauiToolkitsDemo.Services;

public class ProductService
{
    public List<Product> Products = [];

    public ProductService()
    {
        Products = new List<Product>()
        {
            new Product()
            {
                Id = 1,
                Name = ".NET Maui in Action",
                Price = 20.00m
            },
            new Product()
            {
                Id = 2,
                Name = "Web Development with Blazor",
                Price = 30.00m
            },
            new Product()
            {
                Id = 3,
                Name = "C# in Depth",
                Price = 25.00m
            }
        };
    }
}