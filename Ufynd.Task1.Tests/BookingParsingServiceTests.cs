using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;
using Ufynd.Application.Task1.Implementation;

namespace Ufynd.Task1.Tests
{
    public class Tests
    {
        BookingParsingService bookingParsingService;
        [SetUp]
        public void Setup()
        {
            var logger = Mock.Of<ILogger<BookingParsingService>>();
            bookingParsingService = new BookingParsingService(logger);
        }

        [Test]
        public async Task BookingParsingServiceFileInfoRunSuccessfuly()
        {
          
            var file = new FileInfo("task1.html");
            var output=await bookingParsingService.Parse(file);
            Assert.Pass();
        }

        [Test]
        public async Task BookingParsingServiceParseByPathRunSuccessfuly()
        {
            var output = await bookingParsingService.ParseByPath("task1.html");
            Assert.Pass();
        }

        [Test]
        public async Task BookingParsingServiceStreamRunSuccessfuly()
        {
                    
            var stream = File.OpenRead("task1.html");
            var output = await bookingParsingService.Parse(stream);
            Assert.Pass();
        }

        [Test]
        public async Task BookingParsingServiceStringRunSuccessfuly()
        {
           
            var str = File.ReadAllText("task1.html");
            var output =await  bookingParsingService.Parse(str);
            Assert.Pass();
        }
    }
}