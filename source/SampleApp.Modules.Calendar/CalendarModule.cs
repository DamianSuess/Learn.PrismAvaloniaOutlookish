using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SampleApp.Modules.Calendar.Views;

namespace SampleApp.Modules.Calendar
{
  public class CalendarModule : IModule
  {
    public void OnInitialized(IContainerProvider containerProvider)
    {
      var regionManager = containerProvider.Resolve<IRegionManager>();
      regionManager.RegisterViewWithRegion("CalendarView", typeof(CalendarView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }
  }
}