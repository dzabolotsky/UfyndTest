using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufynd.Common.DTO;
using Ufynd.Common.Implementation;
using Ufynd.Task2.Application.Implementation;

namespace Ufynd.Task2.Tests
{
    public class DataServiceTest
    {
        [SetUp]
        public void Setup()
        {           
        }

        [Test]
        public async Task DataServiceRunSuccessfuly()
        {            
            var dataService = new DataService();
            var content = File.ReadAllText("task2.json");
            var data= await dataService.GetData<HotelInfoDTO>(content);
            Assert.IsNotNull(data);
            Assert.IsNotNull(data.Hotel);
            Assert.IsNotNull(data.HotelRates);
            Assert.AreEqual(7294, data.Hotel.HotelId);
            Assert.AreEqual(104, data.HotelRates.Count());
            Assert.Pass();
        }

    }
}
