using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SampleApp.Modules.Contacts.Views;

namespace SampleApp.Modules.Contacts
{
  public class ContactsModule : IModule
  {
    public void OnInitialized(IContainerProvider containerProvider)
    {
      var regionManager = containerProvider.Resolve<IRegionManager>();
      regionManager.RegisterViewWithRegion("ContactsView", typeof(ContactsView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }
  }
}