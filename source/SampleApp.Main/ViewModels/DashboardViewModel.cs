using Avalonia.Controls.Notifications;
using Prism.Commands;
using Prism.Regions;
using SampleApp.Common;

namespace SampleApp.ViewModels
{
  public class DashboardViewModel : ViewModelBase
  {
    private IRegionManager _regionManager;
    ////private IManagedNotificationManager _notifications;

    public DashboardViewModel(IRegionManager regionManager) ////, IManagedNotificationManager notifyMngr)
    {
      _regionManager = regionManager;
      ////_notifications = notifyMngr;

      Title = "Dashboard - No New Messages";
    }

    ////public DelegateCommand CommandTestNotification => new DelegateCommand(OnNotification);
    ////
    ////private void OnNotification()
    ////{
    ////  _notifications.Show(
    ////    new Avalonia.Controls.Notifications.Notification(
    ////      "Welcome",
    ////      "Sample Message",
    ////      NotificationType.Information));
    ////
    ////  // Sample from Avalonia
    ///   // NOTE
    ///   //  - MainWindow.xaml.cs needs the WindowNotificationManager initialized first.
    ////  ////ShowManagedNotificationCommand = MiniCommand.Create(() =>
    ////  ////{
    ////  ////  NotificationManager.Show(new Avalonia.Controls.Notifications.Notification("Welcome", "Avalonia now supports Notifications.", NotificationType.Information));
    ////  ////});
    ////
    ////  ////ShowCustomManagedNotificationCommand = MiniCommand.Create(() =>
    ////  ////{
    ////  ////  NotificationManager.Show(new NotificationViewModel(NotificationManager) { Title = "Hey There!", Message = "Did you know that Avalonia now supports Custom In-Window Notifications?" });
    ////  ////});
    ////  
    ////}
  }
}
