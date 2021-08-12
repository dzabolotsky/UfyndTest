using AutoMapper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufynd.Common.Implementation;
using Ufynd.Task2.Application.Enums;
using Ufynd.Task2.Application.Implementation;

namespace Ufynd.Task2.Tests
{
    public class XlsProcessingServiceTest
    {
        AppSettings _appSettings;
        [SetUp]
        public void Setup()
        {

            var config = new MapperConfiguration(cfg => cfg.AddProfile<ApplicationProfile>());
            var mapper = config.CreateMapper();
            var xlsProcessingService = new XlsProcessingService();
            var dataService = new DataService();
            _appSettings = new AppSettings { InputFilePath = "task2.json" };

            if (Directory.Exists(_appSettings.OutputFolderPath))
                Directory.Delete(_appSettings.OutputFolderPath, true);
        }
        private IEnumerable<HeaderColumn> GetColumns()
        {
            var columns = new List<HeaderColumn>();
            columns.Add(new HeaderColumn("TestColumn", "Test Data", 40, AlighmentEnum.Center));
            return columns;
        }

        private record TestItem(int TestColumn);
        [Test]
        public async Task WorkerRunSuccessfuly()
        {
            var service = new XlsProcessingService();
            var items = new List<TestItem>();
            for (int i = 0; i <= 30; i++)
                items.Add(new TestItem(i));
            await service.CreateDocument(GetColumns(), items, "Test Report", Path.Combine(_appSettings.OutputFolderPath, "test.xlsx"));
            var files = Directory.GetFiles(_appSettings.OutputFolderPath);
            Assert.AreEqual(1, files.Length);
            Assert.AreEqual("test.xlsx", Path.GetFileName(files[0]));
        }
    }
}
