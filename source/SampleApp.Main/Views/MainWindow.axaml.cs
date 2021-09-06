using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Markup.Xaml;
using Prism.Ioc;

namespace SampleApp.Views
{
  public partial class MainWindow : Window
  {
    private WindowNotificationManager _notificationArea;

    public MainWindow()
    {
      InitializeComponent();
#if DEBUG
      this.AttachDevTools();
#endif

      // SAMPLE Avalonia Notifications
      // To wire-up Notifications, we'll need Prism 8.1 to access ContainerLocator.

      _notificationArea = new WindowNotificationManager(this) {
        Position = NotificationPosition.TopRight,
        MaxItems = 3
      };

      // Avalonia sample passes this along.
      // However, we'll add it to our Prism Container ;)
      //// DataContext = new MainWindowViewModel(_notificationArea);
      //
      // _regionNavigationService = ContainerLocator.Container.Resolve<IRegionNavigationService>();
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }
  }
}