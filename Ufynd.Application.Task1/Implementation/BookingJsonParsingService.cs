using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Ufynd.Application.Task1.Interfaces;

[assembly: InternalsVisibleTo("Ufynd.Task1.Tests")]
namespace Ufynd.Application.Task1.Implementation
{
    /// <summary>
    /// Implemented only by task description
    /// Usually this is th thing you should never do. The Service should return an object and decision about formats and everything should do calling side. 
    /// The example see on Ufynd.Task1.Web
    /// Now it's only a wrapper for normal service BookingParsingService
    /// </summary>
    internal class BookingJsonParsingService : IBookingJsonParsingService
    {
        private readonly IBookingParsingService _bookingParsingService;

        public BookingJsonParsingService(IBookingParsingService bookingParsingService)
        {
            _bookingParsingService = bookingParsingService;
        }
        public async Task<string> Parse(Stream stream)
        {
            var result =await _bookingParsingService.Parse(stream);
            return JsonConvert.SerializeObject(result);
        }

        public async Task<string> Parse(FileInfo file)
        {
            var result =await _bookingParsingService.Parse(file);
            return JsonConvert.SerializeObject(result);
        }

        public async Task<string> Parse(string content)
        {
            var result =await _bookingParsingService.Parse(content);
            return JsonConvert.SerializeObject(result);
        }
    }
}
