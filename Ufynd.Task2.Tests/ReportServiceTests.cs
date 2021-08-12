using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;
using Ufynd.Common.Implementation;
using Ufynd.Task2.Application.Implementation;

namespace Ufynd.Task1.Tests
{
    public class Tests
    {
        const string sampleName= "task2.json";
        ReportService reportService;
        [SetUp]
        public void Setup()
        {
            var logger = Mock.Of<ILogger<ReportService>>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ApplicationProfile>());
            var mapper = config.CreateMapper();
            var xlsProcessingService = new XlsProcessingService();
            var dataService = new DataService();
            var appSettings = new AppSettings { InputFilePath = "task1.html" };
            reportService = new ReportService(logger,xlsProcessingService, mapper,dataService,appSettings);
        }

        [Test]
        public async Task BookingParsingServiceFileInfoRunSuccessfuly()
        {
          
            var file = new FileInfo(sampleName);
            await reportService.GenerateReport(file);
            Assert.Pass();
        }

        [Test]
        public async Task BookingParsingServiceStreamRunSuccessfuly()
        {
                    
            var stream = File.OpenRead(sampleName);
            await reportService.GenerateReport(stream);
            Assert.Pass();
        }

        [Test]
        public async Task BookingParsingServiceStringRunSuccessfuly()
        {
           
            var str = File.ReadAllText(sampleName);
            await  reportService.GenerateReport(str);
            Assert.Pass();
        }
    }
}