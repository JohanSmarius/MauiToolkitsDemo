using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiToolkitsDemo.ViewModels;

public partial class SignOrderViewModel : ObservableObject
{
    public ObservableCollection<IDrawingLine> DrawingLines { get; } = new();

    [RelayCommand]
    private async Task SaveSignature()
    {
        
    }
}