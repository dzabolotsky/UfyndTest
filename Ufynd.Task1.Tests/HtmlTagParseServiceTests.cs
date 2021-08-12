using HtmlAgilityPack;
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

namespace Ufynd.Task1.Tests
{
    public class HtmlTagParseServiceTests
    {
        HtmlDocument _doc = new HtmlDocument();
        HtmlExtractTagService _htmlExtractTagService;
        [SetUp]
        public void Setup()
        {
            var content = File.ReadAllText("task1.html");
            _doc.LoadHtml(content);
            _htmlExtractTagService = new HtmlExtractTagService(_doc);
        }

        [Test]
        public void HtmlExtractNameTest()
        {
            var name=_htmlExtractTagService.GetName();
            Assert.AreEqual("Kempinski Hotel Bristol Berlin", name);
           
        }

        [Test]
        public void HtmlExtractNumbersOfReviewTest()
        {
            var result = _htmlExtractTagService.GetNumbersOfReview();
            Assert.AreEqual(1401, result);

        }

        [Test]
        public void HtmlExtractReviewPointTest()
        {
            var result = _htmlExtractTagService.GetReviewPoints();
            Assert.AreEqual(8.3, result);

        }

        [Test]
        public void HtmlExtractRoomCategoriesTest()
        {
            var result = _htmlExtractTagService.GetRoomCategories();
            Assert.AreEqual(7, result.Count());

        }

        [Test]
        public void HtmlExtractAltHotelsTest()
        {
            var result = _htmlExtractTagService.GetAltHotels();
            Assert.AreEqual(4, result.Count());

        }

        [Test]
        public void HtmlExtractAddressTest()
        {
            var result = _htmlExtractTagService.GetAddress();
            Assert.IsNotNull(result);

        }

        [Test]
        public void HtmlExtractStarsTest()
        {
            var result = _htmlExtractTagService.GetStars();
            Assert.AreEqual("5", result);

        }

        [Test]
        public void HtmlExtractDescriptionTest()
        {
            var result = _htmlExtractTagService.GetDescription();
            Assert.IsNotNull(result);

        }
    }
}
