using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;
using Ufynd.Application.Task1.Implementation;
using Ufynd.Application.Task1.Interfaces;

namespace Ufynd.Task1.Tests
{
    public class BookingJsonParsingServiceTests
    {
        BookingJsonParsingService bookingJsonParsingService;
        [SetUp]
        public void Setup()
        {
            var logger = Mock.Of<ILogger<BookingParsingService>>();
            BookingParsingService bookingParsingService = new BookingParsingService(logger);
            bookingJsonParsingService = new BookingJsonParsingService((IBookingParsingService)bookingParsingService);
        }

        [Test]
        public async Task BookingJsonParsingServiceFileInfoRunSuccessfuly()
        {            
            
            var file = new FileInfo("task1.html");
            var output= await bookingJsonParsingService.Parse(file);
            Assert.Pass();
        }

        [Test]
        public async Task BookingParsingServiceStreamRunSuccessfuly()
        {                     
            var stream = File.OpenRead("task1.html");
            var output =await  bookingJsonParsingService.Parse(stream);
            Assert.Pass();
        }

        [Test]
        public async Task BookingParsingServiceStringRunSuccessfuly()
        {
           
            var str = File.ReadAllText("task1.html");
            var output =await  bookingJsonParsingService.Parse(str);
            Assert.Pass();
        }
    }
}