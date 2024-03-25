using System.Windows;

namespace NetworkStatusOverlayApp;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private WindowSinker _sinker;

    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();

    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        _sinker = new WindowSinker(this);
        _sinker.Sink();

        Left = (SystemParameters.PrimaryScreenWidth / 2) - (this.Width / 2);
        Top = 0;
    }
}