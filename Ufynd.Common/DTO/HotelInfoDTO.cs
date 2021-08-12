using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufynd.Common.DTO
{
    public class HotelInfoDTO
    {
        public HotelDTO Hotel { get; set; }

        public IEnumerable<HotelRateDTO> HotelRates { get; set; }
    }
}
