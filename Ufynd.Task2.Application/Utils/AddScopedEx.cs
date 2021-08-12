using Microsoft.Extensions.DependencyInjection;
using Ufynd.Common.Implementation;
using Ufynd.Common.Interfaces;
using Ufynd.Task2.Application.Implementation;
using Ufynd.Task2.Application.Interfaces;

namespace Ufynd.Task2.Application.Utils
{
    public static class AddScopedEx
    {
        public static void AddScoped(this IServiceCollection services)
        {
            services.AddTransient<IXlsProcessingService, XlsProcessingService>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<IDataService, DataService>();

        }
    }
}
