using Prism.Commands;
using Prism.Dialogs;
using Prism.Navigation.Regions;
using SampleApp.Common;
using SampleApp.Services;
using SampleApp.Views;

namespace SampleApp.ViewModels;

public class DashboardViewModel : ViewModelBase
{
  private readonly IDialogService _dialogService;
  private readonly INotificationService _notificationService;
  private IRegionNavigationJournal? _journal;
  private IRegionManager _regionManager;

  public DashboardViewModel(IRegionManager regionManager, IDialogService dialogService, INotificationService notifyService)
  {
    _regionManager = regionManager;
    _dialogService = dialogService;
    _notificationService = notifyService;

    Title = "Dashboard - No New Messages";
  }

  public DelegateCommand CmdShowMail => new(() =>
  {
    // Both methods work.
    //  The 'GoBack' uses journaling, however if it is not possible
    //  Prism will use the MailView which has been registered by the Mail module.
    if (_journal != null && _journal.CanGoBack)
      _journal.GoBack();
    else
      _regionManager.RequestNavigate(RegionNames.ContentRegion, "MailView");
  });

  public DelegateCommand CmdTestNotification => new(() =>
  {
    var dialogMsg = "You clicked the Notification :)";

    // Method 1 - Dependency Injection
    _notificationService.Show("Hello 2", "I'm from DI Service!", () =>
    {
      _dialogService.ShowDialog(
        nameof(MessageBoxView),
        new DialogParameters($"message={dialogMsg}"),
        _ => { });
    });

    // Method 2 - Static Class
    ////SampleApp.Helpers.NotificationHelpers.Show("Hello", "Im a message", () =>
    ////{
    ////  _dialogService.ShowDialog(nameof(MessageBoxView));
    ////});
  });

  public override void OnNavigatedTo(NavigationContext navigationContext)
  {
    _journal = navigationContext.NavigationService.Journal;
  }
}
