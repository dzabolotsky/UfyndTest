using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufynd.Task2.Application.DTO
{
    public class ReportDTO
    {
        public DateTime ArrivalDate { get; set; }

        public DateTime DepartureDate { get; set; }

        public float Price { get; set; }

        public string Currency { get; set; }

        public string RateName { get; set; }

        public int Adults { get; set; }

        public bool IsBreakfastIncluded { get; set; }
    }
}
