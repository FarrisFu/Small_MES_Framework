using JCF.Module.Common.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace JCF.Module.Common
{
    public class CommonModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterForNavigation<LoadingView>(nameof(LoadingView));
        }
    }
}