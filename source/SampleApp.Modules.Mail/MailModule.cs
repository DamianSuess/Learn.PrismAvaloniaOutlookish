using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SampleApp.Common;
using SampleApp.Modules.Mail.Services;
using SampleApp.Modules.Mail.ViewModels;
using SampleApp.Modules.Mail.Views;

namespace SampleApp.Modules.Mail
{
  public class MailModule : IModule
  {
    public void OnInitialized(IContainerProvider containerProvider)
    {
      var regionManager = containerProvider.Resolve<IRegionManager>();
      regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(MailView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
      containerRegistry.Register<IMailService, MailService>();
      containerRegistry.RegisterInstance(typeof(MailViewModel));
    }
  }
}