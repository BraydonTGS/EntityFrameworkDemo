using EntityFrameworkDemo.Business.Config;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace EntityFrameworkDemo.WPF
{
    public partial class App : Application
    {
        private static IServiceProvider? ServiceProvider { get; set; }

        public App()
        {
            // Register services
            StartUp();

            // Other initialization code
        }

        private void StartUp()
        {
            // Create an instance of the RegisterServices class
            var serviceConfig = new RegisterServices();

            // Get the IServiceCollection from the RegisterServices class
            var services = serviceConfig.ConfigureServices();

            // Build the service provider
            var serviceProvider = services.BuildServiceProvider();

            // Set the application's service provider
            // This will allow you to resolve services throughout the application
            ServiceProvider = serviceProvider;
        }
    }
}
