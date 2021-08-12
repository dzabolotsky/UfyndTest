using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ufynd.Application.Task1.Implementation;
using Ufynd.Application.Task1.Interfaces;
using Ufynd.Common.Interfaces;
using Ufynd.Task1.Application.Implementation;
using Ufynd.Task1.Application.Interfaces;


namespace Ufynd.Task1.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IBookingJsonParsingService _bookingJsonParsingService;
        private readonly IAppSettings _appSettings;
        private readonly ISaveService _saveService;

        public Worker(ILogger<Worker> logger,
                      IBookingJsonParsingService bookingJsonParsingService,
                      AppSettings appSettings,
                      ISaveService saveService)
        {
            _logger = logger;
            _bookingJsonParsingService = bookingJsonParsingService;
            _appSettings = appSettings;
            _saveService = saveService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var file = new FileInfo(_appSettings.InputFilePath);


                var content = await _bookingJsonParsingService.Parse(file);
                _logger.LogInformation(content);
                await _saveService.Save(content, _appSettings.OutputFolderPath, "json");

            }
            catch (Exception ex)
            {

                _logger.LogError(ex.ToString());
            }

        }
    }
}
