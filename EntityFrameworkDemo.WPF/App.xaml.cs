using EntityFrameworkDemo.Business.Config;
using Microsoft.Extensions.DependencyInjection;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using System.Windows;

namespace EntityFrameworkDemo.WPF
{
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            throw new NotImplementedException();
        }

        protected override Window CreateShell()
        {
            throw new NotImplementedException();
        }
    }
}
