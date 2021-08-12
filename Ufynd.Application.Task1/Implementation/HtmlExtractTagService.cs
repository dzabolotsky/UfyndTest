using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Ufynd.Application.Task1.DTO;
using Ufynd.Application.Task1.Enums;
using Ufynd.Application.Task1.Utils;

[assembly: InternalsVisibleTo("Ufynd.Task1.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2, PublicKey=0024000004800000940000000602000000240000525341310004000001000100c547cac37abd99c8db225ef2f6c8a3602f3b3606cc9891605d02baa56104f4cfc0734aa39b93bf7852f7d9266654753cc297e7d2edfe0bac1cdcf9f717241550e0a7b191195b7667bb4f64bcb8e2121380fd1d9d46ad2d92d2d15605093924cceaf74c4861eff62abf69b9291ed0a340e113be11e6a7d3113e92484cf7045cc7")]

namespace Ufynd.Application.Task1.Implementation
{
    internal class HtmlExtractTagService
    {
        private readonly HtmlDocument _doc;

        public HtmlExtractTagService(HtmlDocument doc)
        {
            _doc = doc;
        }

        public string GetDescription()
        {
            var nodes = _doc.DocumentNode.SelectNodes("//div[@id='summary']//p");
            StringBuilder sb = new StringBuilder();
            foreach (var node in nodes)
            {
                sb.Append(node.InnerText.Trim());
            }
            return sb.ToString();
        }

        public string GetName() => GetByTagInnerText("//span[@id='hp_hotel_name']");

        public string GetAddress() => GetByTagInnerText("//span[@id='hp_address_subtitle']");

        public string GetStars()
        {
            var node = _doc.DocumentNode.SelectSingleNode("//span[@class='hp__hotel_ratings__stars hp__hotel_ratings__stars__clarification_track']//i");
            var str = node.Attributes["class"].Value;
            return Regex.Match(str, @"\d+").Value;
        }

        public double GetReviewPoints() => Convert.ToDouble(GetByTagInnerText("//span[@class='average js--hp-scorecard-scoreval']"), CultureInfo.InvariantCulture);

        public int GetNumbersOfReview() => Convert.ToInt32(GetByTagInnerText("//span[@class='trackit score_from_number_of_reviews']//strong[@class='count']"));

        public IEnumerable<RoomCategoryDTO> GetRoomCategories()
        {
            var roomsTypes = _doc.DocumentNode.SelectNodes("//table[@id='maxotel_rooms']//tbody//tr//td[@class='ftd']").Select(r => r.InnerText.Trim());//room types
            foreach (var roomType in roomsTypes)
            {
                yield return new RoomCategoryDTO 
                { 
                    Category = (RoomCategoryEnum)Enum.Parse(typeof(RoomCategoryEnum), roomType.MakeCapitalEveryWord().RemoveSpecialCharacters()),
                    Description = roomType.RemoveEscapes()
                };

            }           

        }

        public IEnumerable<AltHotelDTO> GetAltHotels()
        {
            var nodes = _doc.DocumentNode.SelectNodes("//table[@id='althotelsTable']//tbody//tr//td[@class='althotelsCell tracked']//p[@class='althotels-name']");//альтернативные отели
            foreach (var n in nodes)
            {
                var nodeAltHotel = n.SelectSingleNode("//a[@class='althotel_link']");
                var altHotelName = nodeAltHotel.InnerText.RemoveEscapes();
                var altHotelLink = nodeAltHotel.Attributes["href"].Value.RemoveEscapes();
                var stars = Regex.Match(n.ChildNodes.FirstOrDefault(r => r.Name == "i")?.InnerText, @"\d+").Value;
                yield return new AltHotelDTO {Name=altHotelName,Stars=stars,Url=new Uri(altHotelLink) };
                // var nodeAltHotelStar= Regex.Match(node.SelectNodes("//i")?.Attributes["title"].Value, @"\d+").Value; 
            }
        }

        private string GetByTagInnerText(string selector)
        {
            var node = _doc.DocumentNode.SelectSingleNode(selector);
            return node.InnerText.Trim();
        }
    }
}
