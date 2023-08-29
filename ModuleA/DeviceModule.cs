using ModuleA.ViewModels;
using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace ModuleA
{
    public class DeviceModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public DeviceModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegion region = _regionManager.Regions["ContentRegion"];
            var deviceView = containerProvider.Resolve<DeviceView>();
            region.Add(deviceView);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<DeviceView, DeviceViewModel>();
        }
    }
}