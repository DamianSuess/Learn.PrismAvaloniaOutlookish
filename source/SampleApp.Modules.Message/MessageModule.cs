using Prism.Ioc;
using Prism.Modularity;
using Prism.Navigation.Regions;
using SampleApp.Common;
using SampleApp.Modules.Message.Views;

namespace SampleApp.Modules.Message
{
  public class MessageModule : IModule
  {
    public void OnInitialized(IContainerProvider containerProvider)
    {
      containerProvider
        .Resolve<IRegionManager>()
        .RegisterViewWithRegion(RegionNames.RightRegion, typeof(MessageView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }
  }
}
