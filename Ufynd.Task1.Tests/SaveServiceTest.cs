using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufynd.Common.Interfaces;
using Ufynd.Task1.Application.Implementation;
using Ufynd.Task1.Client.Implementation;


namespace Ufynd.Task1.Tests
{
    public class SaveServiceTest
    {
       
        ISaveService saveService;
        AppSettings _appSettings;

        [SetUp]
        public void Setup()
        {
           
           
            var logger = Mock.Of<ILogger<SaveService>>();           
            _appSettings = new AppSettings { InputFilePath = "task1.html" };
            saveService = new SaveService(logger);
            if (Directory.Exists(_appSettings.OutputFolderPath))
                Directory.Delete(_appSettings.OutputFolderPath, true);
        }

        [Test]
        public async Task SaveExecutedSuccessfuly()
        {
            await saveService.Save("test",_appSettings.OutputFolderPath,"json");
            var files = Directory.GetFiles(_appSettings.OutputFolderPath);
            Assert.AreEqual(1, files.Length);
            var content = File.ReadAllText(files[0]);
            Assert.AreEqual("test", content);
            Assert.Pass();
        }
    }
}
