using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Views;
using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiToolkitsDemo.ViewModels;

public partial class SignOrderViewModel : ObservableObject
{
    public ObservableCollection<IDrawingLine> DrawingLines { get; } = new();

    [RelayCommand]
    private async Task ReceiveConfirmed()
    {
        await using var stream = await DrawingViewService.GetImageStream(
            ImageLineOptions.JustLines(DrawingLines, new Size(1920, 1080), Brush.Blue));
        
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        var result = await FolderPicker.Default.PickAsync(cancellationTokenSource.Token);

        if (result.IsSuccessful)
        {
            var fileName = Path.Combine(result.Folder.Path, "Signature.png");
            var fileSaverResult = await FileSaver.Default.SaveAsync(fileName, stream, cancellationTokenSource.Token);

            string text = "File saved";
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;

            var toast = Toast.Make(text, duration, fontSize);
            toast.Show();
        }
    }
}