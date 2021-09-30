using System;
using Prism.Commands;
using Prism.Regions;
using SampleApp.Common;

namespace SampleApp.ViewModels
{
  public class DashboardViewModel : ViewModelBase
  {
    private IRegionManager _regionManager;

    public DashboardViewModel(IRegionManager regionManager)
    {
      _regionManager = regionManager;

      Title = "Dashboard - No New Messages";
    }

    public DelegateCommand CommandTestNotification => new DelegateCommand(() =>
    {
      throw new NotImplementedException();
    });

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
