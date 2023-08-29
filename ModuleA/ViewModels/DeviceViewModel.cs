using EntityFrameworkDemo.Business.Dto;
using EntityFrameworkDemo.Business.Services;
using Prism.Mvvm;

namespace ModuleA.ViewModels
{
    public class DeviceViewModel : BindableBase
    {
        #region Private Fields
        private DeviceService _service;
        #endregion

        #region Public Properties
        public DeviceDto Model { get; set; }
        #endregion

        public DeviceViewModel(DeviceService service)
        {
            _service = service;
            Model = new DeviceDto();
        }



    }
}
