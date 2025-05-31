using Prism.Ioc;
using Prism.Modularity;
using Prism.Navigation.Regions;
using SampleApp.Common;
using SampleApp.Modules.Contacts.Views;

namespace SampleApp.Modules.Contacts;

public class ContactsModule : IModule
{
  public void OnInitialized(IContainerProvider containerProvider)
  {
    var regionManager = containerProvider.Resolve<IRegionManager>();
    regionManager.RegisterViewWithRegion(RegionNames.RightRegion, typeof(ContactsView));
  }

  public void RegisterTypes(IContainerRegistry containerRegistry)
  {
  }
}
