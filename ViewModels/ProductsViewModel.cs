using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using MauiToolkitsDemo.Models;
using MauiToolkitsDemo.Services;
using Microsoft.Maui.Controls;

namespace MauiToolkitsDemo.ViewModels;

public class ProductsViewModel : INotifyPropertyChanged
{
    private readonly ProductService _productService;
    public event PropertyChangedEventHandler PropertyChanged;

    private ObservableCollection<Product> _products;
    public ObservableCollection<Product> Products
    {
        get => _products;
        set => SetField(ref _products, value);
    }

    private ICommand _loadProductsCommand;
    public ICommand LoadProductsCommand => _loadProductsCommand ??= new Command(LoadProducts);
    
    public ProductsViewModel(ProductService productService)
    {
        _productService = productService;
        LoadProducts();
        
        LoadProductDetailCommand = new Command<Product>(LoadProductDetail);
    }
    
    private void LoadProducts()
    {
        Products = new ObservableCollection<Product>();
        foreach (var product in _productService.Products)
        {
            Products.Add(product);
        }
    }
    
    public Command<Product> LoadProductDetailCommand { get; }

    private async void LoadProductDetail(Product product)
    {
        if (product is null)
            return;

        // Now navigate to the detail page.
        await Shell.Current.GoToAsync($"{nameof(ProductDetail)}?id={product.Id}");
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}