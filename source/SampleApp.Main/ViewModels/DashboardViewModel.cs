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
  }
}
