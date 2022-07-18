using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Markup.Xaml;
using Prism.Ioc;
using SampleApp.Services;

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

      InitNotifications();
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }

    private void InitNotifications()
    {
      // Forenote:
      //  You can't use the notification window right away
      //  Ref: https://github.com/AvaloniaUI/Avalonia/issues/5442

      // Method 1 - DI Services ------------------
      //  1. Get the NotificationService from our DI ContainerLocator
      //  2. Set MainWindow as our host of the Avalonia Notifications
      // REF: https://prismlibrary.com/docs/dependency-injection/container-locator.html
      var notifyService = ContainerLocator.Current.Resolve<INotificationService>();
      notifyService.SetHostWindow(this);

      // Method 2 - Static Class ------------------
      //
      //SampleApp.Helpers.NotificationHelpers.SetNotificationManager(this);
    }
  }
}