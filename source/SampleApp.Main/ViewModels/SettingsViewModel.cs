using Prism.Navigation.Regions;
using SampleApp.Common;

namespace SampleApp.ViewModels;

public class SettingsViewModel : ViewModelBase
{
  private IRegionManager _regionManager;

  public SettingsViewModel(IRegionManager regionManager)
  {
    _regionManager = regionManager;

    Title = "Settings";
  }
}
