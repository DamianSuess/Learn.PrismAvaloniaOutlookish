using Prism.Ioc;
using Prism.Modularity;
using Prism.Navigation.Regions;
using SampleApp.Common;
using SampleApp.Modules.Calendar.Views;

namespace SampleApp.Modules.Calendar
{
  public class CalendarModule : IModule
  {
    public void OnInitialized(IContainerProvider containerProvider)
    {
      var regionManager = containerProvider.Resolve<IRegionManager>();
      regionManager.RegisterViewWithRegion(RegionNames.LeftRegion, typeof(CalendarView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }
  }
}
