using Avalonia.Controls;
using Prism.Commands;
using Prism.Navigation.Regions;
using SampleApp.Common;
using SampleApp.Services;

namespace SampleApp.Modules.Mail.ViewModels;

public class MailViewModel : ViewModelBase
{
  private IRegionManager _regionManager;
  private int _selectedTabIndex;
  private TabItem _selectedTabItem;

  public MailViewModel(IMailService mailService, IRegionManager regionManager)
  {
    _regionManager = regionManager;
  }

  public DelegateCommand CommandShowDashboard => new(OnShowDashboard);

  public string Greeting => "Mail Region";

  public int SelectedTabIndex { get => _selectedTabIndex; set => SetProperty(ref _selectedTabIndex, value); }

  public TabItem SelectedTabItem { get => _selectedTabItem; set => SetProperty(ref _selectedTabItem, value); }

  private void OnShowDashboard()
  {
    _regionManager.RequestNavigate(RegionNames.ContentRegion, "DashboardView");
  }
}
