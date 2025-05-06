using CommunityToolkit.Maui;
using MauiToolkitsDemo.Services;
using MauiToolkitsDemo.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace MauiToolkitsDemo;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitCamera()
            .UseMauiCommunityToolkitMediaElement()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        
  
        builder.Services.AddSingleton<ProductService>();
        builder.Services.AddSingleton<OrderService>();
        builder.Services.AddTransient<SignOrderViewModel>();
        builder.Services.AddTransient<ProductsViewModel>();
        builder.Services.AddTransient<ProductViewModel>();
        builder.Services.AddTransient<ShoppingCartViewModel>();
        builder.Services.AddTransient<CameraViewModel>();
        
        builder.Services.AddTransientPopup<Customer, CustomerViewModel>();

        return builder.Build();
    }
}