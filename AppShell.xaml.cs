using Microsoft.Maui.Controls;

namespace MauiToolkitsDemo;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute(nameof(ProductDetail), typeof(ProductDetail));
    }
}