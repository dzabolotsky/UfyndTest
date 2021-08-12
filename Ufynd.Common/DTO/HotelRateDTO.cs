using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufynd.Common.DTO
{
    public class HotelRateDTO
    {
        public int Adults { get; set; }

        public int Los { get; set; }

        public PriceDTO Price { get; set; }

        public string RateDescription { get; set; }

        public int RateId { get; set; }

        public string RateName { get; set; }

        public IEnumerable<RateTagDTO> RateTags { get; set; }
        public DateTime TargetDay { get; set; }
    }
}
