using Prism.Ioc;
using Prism.Modularity;
using Prism.Navigation.Regions;
using SampleApp.Common;
using SampleApp.Modules.SampleFooter.ViewModels;
using SampleApp.Modules.SampleFooter.Views;

namespace SampleApp.Modules.SampleFooter
{
  public class SampleFooterModule : IModule
  {
    public void OnInitialized(IContainerProvider containerProvider)
    {
      var regionManager = containerProvider.Resolve<IRegionManager>();
      regionManager.RegisterViewWithRegion(RegionNames.FooterRegion, typeof(SampleFooterView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      // containerRegistry.Register<IMailService, MailService>();
      containerRegistry.RegisterInstance(typeof(SampleFooterViewModel));
    }
  }
}
