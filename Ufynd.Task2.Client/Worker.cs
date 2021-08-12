using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ufynd.Task2.Application.Implementation;
using Ufynd.Task2.Application.Interfaces;

namespace Ufynd.Task2.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IAppSettings _appSettings;
        private readonly IReportService _reportService;

        public Worker(ILogger<Worker> logger, AppSettings appSettings, IReportService reportService)
        {
            _logger = logger;
            _appSettings = appSettings;
            _reportService = reportService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            var content = await File.ReadAllTextAsync(_appSettings.InputFilePath);
            await _reportService.GenerateReport(content);

        }
    }
}
