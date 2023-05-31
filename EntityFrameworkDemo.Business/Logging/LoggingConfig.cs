using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace EntityFrameworkDemo.Business.Logging
{
    public class LoggingConfig
    {
        #region Configure
        public static void Configure()
        {
            var serviceProvider = new ServiceCollection()
           .AddLogging(loggingBuilder =>
           {
               loggingBuilder.ClearProviders();
               loggingBuilder.AddSerilog(dispose: true);
           })
           .BuildServiceProvider();

            var loggerConfiguration = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            loggerFactory.AddSerilog(loggerConfiguration);
        }
        #endregion
    }
}
