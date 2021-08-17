using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SampleApp.Modules.Message.Views;

namespace SampleApp.Modules.Message
{
  public class MessageModule : IModule
  {
    public void OnInitialized(IContainerProvider containerProvider)
    {
      containerProvider
        .Resolve<IRegionManager>()
        .RegisterViewWithRegion("MessageRegion", typeof(MessageView));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }
  }
}