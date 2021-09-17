using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ufynd.Common.Implementation;
using Ufynd.Common.Interfaces;

using Ufynd.Task2.Application.Implementation;
using Ufynd.Task2.Service;

namespace Ufynd.Task1.Tests
{
    public class WorkerTest
    {
     
        ISaveService saveService;
        AppSettings _appSettings;
        ReportService _reportService;

        [SetUp]
        public void Setup()
        {
            var logger = Mock.Of<ILogger<ReportService>>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ApplicationProfile>());
            var mapper = config.CreateMapper();
            var xlsProcessingService = new XlsProcessingService();
            var dataService = new DataService();
            _appSettings = new AppSettings { InputFilePath = "task2.json" };
            _reportService = new ReportService(logger, xlsProcessingService, mapper, dataService, _appSettings);
            if (Directory.Exists(_appSettings.OutputFolderPath))
                Directory.Delete(_appSettings.OutputFolderPath, true);
        }

        [Test]
        public async Task WorkerRunSuccessfuly()
        {
            var logger = Mock.Of<ILogger<Worker>>();
            var worker = new Worker(logger,_appSettings, _reportService);
            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromMinutes(30));
            await worker.StartAsync(tokenSource.Token);
            await worker.StopAsync(tokenSource.Token);
            var files=Directory.GetFiles(_appSettings.OutputFolderPath);
            Assert.AreEqual(1,files.Length);
            Assert.Pass();
        }
    }
}
