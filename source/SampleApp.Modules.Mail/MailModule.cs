using Prism.Ioc;
using Prism.Modularity;
using Prism.Navigation.Regions;
using SampleApp.Common;
using SampleApp.Modules.Mail.ViewModels;
using SampleApp.Modules.Mail.Views;
using SampleApp.Services;

namespace SampleApp.Modules.Mail;

public class MailModule : IModule
{
  public void OnInitialized(IContainerProvider containerProvider)
  {
    var regionManager = containerProvider.Resolve<IRegionManager>();

    // Main Window's Content Region
    regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(MailView));

    // Mail Module's Tab Region
    regionManager.RegisterViewWithRegion(RegionNames.MailTabRegion, typeof(MailFocusedView));
    regionManager.RegisterViewWithRegion(RegionNames.MailTabRegion, typeof(MailOtherView));
  }

  public void RegisterTypes(IContainerRegistry containerRegistry)
  {
    containerRegistry.Register<IMailService, MailService>();
    containerRegistry.RegisterInstance(typeof(MailViewModel));

    // The views are auto-registered, the following is not needed
    // containerRegistry.RegisterForNavigation<MailFocusedView, MailFocusedViewModel>();
    // containerRegistry.RegisterForNavigation<MailOtherView, MailOtherViewModel>();
  }
}
