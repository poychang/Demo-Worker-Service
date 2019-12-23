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
                    // �`�J appsettings.json �]�w��
                    services.Configure<AppSettings>(hostContext.Configuration);
                    // ���U�̩ۨʪ`�J���A��
                    services.AddSingleton<TimeService>();
                    // ���U�D�n�Ұʪ� Service �A��
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
