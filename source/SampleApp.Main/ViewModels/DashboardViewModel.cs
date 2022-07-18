using Prism.Commands;
using Prism.Regions;
using Prism.Services.Dialogs;
using SampleApp.Common;
using SampleApp.Helpers;
using SampleApp.Views;

namespace SampleApp.ViewModels
{
  public class DashboardViewModel : ViewModelBase
  {
    private readonly IDialogService _dialogService;
    private IRegionNavigationJournal? _journal;
    private IRegionManager _regionManager;

    public DashboardViewModel(IRegionManager regionManager, IDialogService dialogService)
    {
      _regionManager = regionManager;
      _dialogService = dialogService;

      Title = "Dashboard - No New Messages";
    }

    public DelegateCommand CmdShowMail => new DelegateCommand(() =>
    {
      // Both methods work.
      //  The 'GoBack' uses journaling, however if it is not possible
      //  Prism will use the MailView which has been registered by the Mail module.
      if (_journal != null && _journal.CanGoBack)
        _journal.GoBack();
      else
        _regionManager.RequestNavigate(RegionNames.ContentRegion, "MailView");
    });

    public DelegateCommand CmdTestNotification => new DelegateCommand(() =>
    {
      // Hard-Coded singleton ability to show notification (NON-DI approach)
      NotificationHelpers.Show("Hello", "Im a message", () =>
      {
        _dialogService.ShowDialog(nameof(NoticeDialogView));
      });
    });

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
      _journal = navigationContext.NavigationService.Journal;
    }

    /*
    private IRegionManager _regionManager;
    private IManagedNotificationManager _notifications;

    public DashboardViewModel(IRegionManager regionManager, IManagedNotificationManager notifyMngr)
    {
      _regionManager = regionManager;
      _notifications = notifyMngr;

      Title = "Dashboard - No New Messages";
    }

    public DelegateCommand CommandTestNotification => new DelegateCommand(OnNotification);

    private void OnNotification()
    {
      // Prism 8.x
      //  ContainerLocator.Container.Resolve<IContainerRegistry>();
      //
      // Prism 7.x
      var containerRegistry = CommonServiceLocator.ServiceLocator.Current.GetInstance<IContainerRegistry>();

      if (!containerRegistry.IsRegistered<IManagedNotificationManager>())
      {
        Console.WriteLine("Danger! Danger! Null object is about to happen");
      }

      _notifications.Show(
        new Avalonia.Controls.Notifications.Notification(
          "Welcome",
          "Sample Message",
          NotificationType.Information));

      // Sample from Avalonia
      //// NOTE
      ////  - MainWindow.xaml.cs needs the WindowNotificationManager initialized first.
      ////ShowManagedNotificationCommand = MiniCommand.Create(() =>
      ////{
      ////  NotificationManager.Show(new Avalonia.Controls.Notifications.Notification("Welcome", "Avalonia now supports Notifications.", NotificationType.Information));
      ////});

      ////ShowCustomManagedNotificationCommand = MiniCommand.Create(() =>
      ////{
      ////  NotificationManager.Show(new NotificationViewModel(NotificationManager) { Title = "Hey There!", Message = "Did you know that Avalonia now supports Custom In-Window Notifications?" });
      ////});
    }
    */
  }
}
