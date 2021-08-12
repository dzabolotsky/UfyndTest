using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufynd.Application.Task1.Implementation;
using Ufynd.Application.Task1.Interfaces;
using Ufynd.Common.Interfaces;
using Ufynd.Task1.Application.Implementation;
using Ufynd.Task1.Application.Interfaces;
using Ufynd.Task1.Client.Implementation;
using Ufynd.Task1.Service;

namespace Ufynd.Task1.Tests
{
    public class WorkerTest
    {
        IBookingJsonParsingService _bookingJsonParsingService;
        ISaveService _saveService;
        AppSettings _appSettings;

        [SetUp]
        public void Setup()
        {
           // var logger = Mock.Of<ILogger<Worker>>();
            var loggerService = Mock.Of<ILogger<BookingParsingService>>();
            var loggerSaveService = Mock.Of<ILogger<SaveService>>();
            BookingParsingService bookingParsingService = new BookingParsingService(loggerService);
            _bookingJsonParsingService = new BookingJsonParsingService((IBookingParsingService)bookingParsingService);
            _appSettings = new AppSettings { InputFilePath = "task1.html" };
            _saveService = new SaveService(loggerSaveService);
            if (Directory.Exists(_appSettings.OutputFolderPath))
                Directory.Delete(_appSettings.OutputFolderPath,true);
        }

        [Test]
        public async Task WorkerRunSuccessfuly()
        {
            var logger = Mock.Of<ILogger<Worker>>();
            var worker = new Worker(logger, _bookingJsonParsingService, _appSettings, _saveService);
            await worker.StartAsync(System.Threading.CancellationToken.None);
            await worker.StopAsync(System.Threading.CancellationToken.None);
            var files=Directory.GetFiles(_appSettings.OutputFolderPath);
            Assert.AreEqual(1,files.Length);
            Assert.Pass();
        }
    }
}
