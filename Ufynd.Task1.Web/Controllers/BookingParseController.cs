using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ufynd.Application.Task1.DTO;
using Ufynd.Application.Task1.Interfaces;
using Ufynd.Task1.Application.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ufynd.Task1.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingParseController : ControllerBase
    {
        private readonly IBookingParsingService _bookingParsingService;
        private readonly AppSettings _appSettings;

        public BookingParseController(IBookingParsingService bookingParsingService, IOptions<AppSettings> appSettingsOption)
        {
            _bookingParsingService = bookingParsingService;
            _appSettings = appSettingsOption?.Value;
        }
        // GET: api/<BookingParseController>
        [HttpGet]
        public Task<HotelDTO> Get() => _bookingParsingService.ParseByPath(_appSettings.InputFilePath);       


    }
}
