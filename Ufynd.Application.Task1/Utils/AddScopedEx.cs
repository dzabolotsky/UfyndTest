using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Ufynd.Application.Task1.Implementation;
using Ufynd.Application.Task1.Interfaces;

namespace Ufynd.Application.Task1.Utils
{
    public static class AddScopedEx
    {
        public static void AddScoped(this IServiceCollection services)
        {
            services.AddTransient<IBookingParsingService, BookingParsingService>();
            services.AddTransient<IBookingJsonParsingService, BookingJsonParsingService>();
        }
    }
}
