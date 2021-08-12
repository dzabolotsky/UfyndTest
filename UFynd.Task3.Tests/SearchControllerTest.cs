using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Ufynd.Common.Implementation;
using UFynd.Task3.Web.Controllers;
using UFynd.Task3.Web.Implementation;

namespace UFynd.Task3.Tests
{
    public class SearchControllerTest
    {
        SearchService searchService;
        [SetUp]
        public void Setup()
        {
            var appSettings = new AppSettings { InputFilePath = "task3.json" };
            // Make sure you include using Moq;
            var mock = new Mock<IOptions<AppSettings>>();
            // We need to set the Value of IOptions to be the SampleOptions Class
            mock.Setup(ap => ap.Value).Returns(appSettings);
            var dataService = new DataService();
            searchService = new SearchService(dataService, mock.Object);
        }

        [Test]
        public async Task SearchControllerRunTest()
        {
            var controller = new SearchController(searchService);
            var response = await controller.Get(new SearchModel(7294, DateTime.Parse("2016-03-15T00:00:00")));
            Assert.AreEqual(1, response.Count());
            Assert.AreEqual(7294, response.FirstOrDefault().Hotel.HotelId);

        }
    }
}
