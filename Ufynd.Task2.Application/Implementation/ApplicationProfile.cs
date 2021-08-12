using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufynd.Common.DTO;
using Ufynd.Task2.Application.DTO;

namespace Ufynd.Task2.Application.Implementation
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<HotelRateDTO, ReportDTO>()
            .ForMember(r => r.ArrivalDate, mdt => mdt.MapFrom(n => n.TargetDay))
            .ForMember(r => r.DepartureDate, mdt => mdt.MapFrom(n => n.TargetDay.AddDays(n.Los)))
            .ForMember(r => r.Price, mdt => mdt.MapFrom(n => n.Price.NumericFloat))
            .ForMember(r => r.Currency, mdt => mdt.MapFrom(n => n.Price.Currency))
            .ForMember(r => r.IsBreakfastIncluded, mdt => mdt.MapFrom(n => n.RateTags.Any(r => r.Name == "breakfast" && r.Shape)));
        }
    }
}
