using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufynd.Application.Task1.Implementation;

namespace Ufynd.Application.Task1.DTO
{
    public class HotelDTO
    {
        /// <summary>
        /// Hotel name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Classification / stars
        /// </summary>
        public string Stars { get; set; }
        /// <summary>
        /// Review points
        /// </summary>
        public double ReviewPoints { get; set; }
        /// <summary>
        /// Number of reviews
        /// </summary>
        public int NumberOfReviews { get; set; }

        /// <summary>
        /// Hotel Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Room categories
        /// </summary>
        public IEnumerable<RoomCategoryDTO> RoomCategories { get; set; }
        /// <summary>
        /// Alternative hotels
        /// </summary>
        public IEnumerable<AltHotelDTO> AlternativeHotels { get; set; }

        internal static HotelDTO Create(HtmlDocument doc, HtmlExtractTagService htmlExtractTagService) 
        {
            var result = new HotelDTO();
            result.Address = htmlExtractTagService.GetAddress();
            result.Description = htmlExtractTagService.GetDescription();
            result.AlternativeHotels = htmlExtractTagService.GetAltHotels();
            result.Name = htmlExtractTagService.GetName();
            result.NumberOfReviews = htmlExtractTagService.GetNumbersOfReview();
            result.RoomCategories = htmlExtractTagService.GetRoomCategories();
            result.Stars = htmlExtractTagService.GetStars();
            result.NumberOfReviews = htmlExtractTagService.GetNumbersOfReview();
            return result;
        }



    }
}
