using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ufynd.Task2.Application.Implementation;
using Ufynd.Task2.Application.Utils;
using Ufynd.Task2.Service;

namespace Ufynd.Task2.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                logger.Debug("Start app");
                var path = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;

                Directory.SetCurrentDirectory(path);
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error in init");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var configuration = hostContext.Configuration;
                    var appSettings = configuration.GetSection("appSettings").Get<AppSettings>();
                    services.AddSingleton(appSettings);
                    services.AddScoped();                    
                    services.AddHostedService<Worker>();
                    services.AddAutoMapper(typeof(ApplicationProfile).Assembly);
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Debug);
                })
                .UseNLog();

    }
}
