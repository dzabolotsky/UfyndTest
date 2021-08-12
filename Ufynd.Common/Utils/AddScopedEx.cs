

using Microsoft.Extensions.DependencyInjection;
using Ufynd.Common.Implementation;
using Ufynd.Common.Interfaces;
using Ufynd.Task1.Client.Implementation;

namespace Ufynd.Common.Utils
{
    public static class AddScopedEx
    {
        public static void AddScopedCommon(this IServiceCollection services)
        {
            services.AddTransient<ISaveService, SaveService>();
            services.AddTransient<IDataService, DataService>();

        }
    }
}
