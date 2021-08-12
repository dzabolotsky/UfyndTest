using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufynd.Common.DTO
{
    public class HotelDTO
    {
        public int HotelId { get; set; }

        public string Classification { get; set; }

        public double ReviewScore { get; set; }

        public string Name { get; set; }
    }
}
