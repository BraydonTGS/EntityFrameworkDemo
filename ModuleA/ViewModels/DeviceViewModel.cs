using EntityFrameworkDemo.Business.Dto;
using EntityFrameworkDemo.Business.Services;
using Prism.Mvvm;

namespace ModuleA.ViewModels
{
    public class DeviceViewModel : BindableBase
    {
        #region Private Fields
        private DeviceDto _model;
        #endregion

        #region Public Properties
        public DeviceDto Model
        {
            get => _model;
            set => SetProperty(ref _model, value);
        }
        #endregion

        public DeviceViewModel()
        {
           
            Model = new DeviceDto()
            {
                Name = "Device One", 
                Description = "Testing View Model Device One"
            };
        }



    }
}
