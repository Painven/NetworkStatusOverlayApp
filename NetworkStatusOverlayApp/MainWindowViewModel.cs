using CommunityToolkit.Mvvm.ComponentModel;
using Humanizer;
using NetworkStatusOverlayApp.BL;


namespace NetworkStatusOverlayApp;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly NM_Monitor networkMonitor = new();
    private readonly System.Timers.Timer refreshTimer = new();

    [ObservableProperty]
    private string downloadSpeedString = string.Empty;

    [ObservableProperty]
    private string uploadSpeedString = string.Empty;

    public MainWindowViewModel()
    {
        if (networkMonitor.arrAdapters.Length == 0)
        {
            Console.WriteLine("No network adapters found.");
            return;
        }

        networkMonitor.Start();

        refreshTimer.Interval = TimeSpan.FromSeconds(1).TotalMilliseconds;
        refreshTimer.Elapsed += (o, e) =>
        {
            try
            {
                DownloadSpeedString = networkMonitor.arrAdapters[0].DownloadSpeedKbps.Kilobytes().Humanize();
                UploadSpeedString = networkMonitor.arrAdapters[0].UploadSpeedKbps.Kilobytes().Humanize();
            }
            catch
            {
                DownloadSpeedString = "Ошибка";
                UploadSpeedString = "Ошибка";
            }
        };
        refreshTimer.Start();
    }
}
