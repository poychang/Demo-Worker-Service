using DemoWorkerService.Models;
using DemoWorkerService.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace DemoWorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    // 注入 appsettings.json 設定檔
                    services.Configure<AppSettings>(hostContext.Configuration);
                    // 註冊相依性注入的服務
                    services.AddSingleton<TimeService>();
                    // 註冊主要啟動的 Service 服務
                    services.AddHostedService<Worker>();
                })
                .UseSerilog((hostContext, logger) =>
                {
                    logger.MinimumLevel.Information();
                    logger.WriteTo.Console();
                    logger.WriteTo.File("logs\\log-.log", rollingInterval: RollingInterval.Day);
                });
    }
}
