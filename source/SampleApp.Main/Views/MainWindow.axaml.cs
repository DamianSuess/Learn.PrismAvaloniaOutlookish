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

      InitNotifications();
    }

    private void InitializeComponent()
    {
      AvaloniaXamlLoader.Load(this);
    }

    private void InitNotifications()
    {
      // SAMPLE Avalonia Notifications
      // To wire-up Notifications, we'll need Prism 8.1 to access ContainerLocator.

      _notificationArea = new WindowNotificationManager(this) {
        Position = NotificationPosition.TopRight,
        MaxItems = 3
      };

      // Try #3 - 
      //// // Register object with default constructor
      //// //  - https://prismlibrary.com/docs/dependency-injection/registering-types.html
      //// //  - https://github.com/dadhi/DryIoc/blob/master/docs/DryIoc.Docs/RulesAndDefaultConventions.md#default-constructor-selection
      //// //
      //// CommonServiceLocator.IServiceLocator locator = CommonServiceLocator.ServiceLocator.Current;
      //// var container = locator.GetInstance<IContainerRegistry>();
      //// 
      //// container.RegisterInstance<IManagedNotificationManager>(new WindowNotificationManager(this) {
      ////   Position = NotificationPosition.TopRight,
      ////   MaxItems = 3,
      //// });

      // Try #2 - DryIoc ONLY, not compatible with Prism.Ioc
      //// container.RegisterSingleton<IManagedNotificationManager, WindowNotificationManager>
      ////   (Made.Of(
      ////     () => new WindowNotificationManager(Arg.Of<Window>(this))));
      ////
      //// container.Register<WindowNotificationManager>
      ////   (Made.Of(
      ////     () => new WindowNotificationManager(Arg.Of<Window>(this))));

      // -----------------

      // Prism 7.x - Getting a container item
      //// TODO: Use, IManagedNotificationManager & register _notificationArea with container.
      //// Sample:
      ////  CommonServiceLocator.IServiceLocator locator = CommonServiceLocator.ServiceLocator.Current;
      ////  DelayedRegionCreationBehavior regionCreationBehavior = locator.GetInstance<DelayedRegionCreationBehavior>();

      // Avalonia Sample:
      //// DataContext = new MainWindowViewModel(_notificationArea);
      //
      // _regionNavigationService = ContainerLocator.Container.Resolve<IRegionNavigationService>();
    }
  }
}