using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SampleApp.Module.SampleFooter.ViewModels;
using SampleApp.Module.SampleFooter.Views;

namespace SampleApp.Module.SampleFooter
{
  public class SampleFooterModule : IModule
  {
    public void OnInitialized(IContainerProvider containerProvider)
    {
      var regionManager = containerProvider.Resolve<IRegionManager>();
      regionManager.RegisterViewWithRegion("FooterRegion", typeof(SampleFooterView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      // containerRegistry.Register<IMailService, MailService>();
      containerRegistry.RegisterInstance(typeof(SampleFooterViewModel));
    }
  }
}
