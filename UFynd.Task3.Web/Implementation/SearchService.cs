using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ufynd.Common.DTO;
using Ufynd.Common.Interfaces;
using UFynd.Task3.Web.Interfaces;

namespace UFynd.Task3.Web.Implementation
{
    public record SearchModel(int HotelId, DateTime arrivalDate);
    public class SearchService : ISearchService
    {
        private readonly IDataService _dataService;
        private readonly AppSettings _appSettings;

        public SearchService(IDataService dataService, IOptions<AppSettings> appSettingsOptions)
        {
            _dataService = dataService;
            _appSettings = appSettingsOptions?.Value;
        }
        private string GetContent() => File.ReadAllText(_appSettings.InputFilePath);


        public async Task<IEnumerable<HotelInfoDTO>> Search(SearchModel search)
        {
            var data = await _dataService.GetData<IEnumerable<HotelInfoDTO>>(GetContent());
            return data.Where(r => r.Hotel.HotelId == search.HotelId && r.HotelRates.Any(hr => hr.TargetDay.Date == search.arrivalDate.Date))
                .Select(r => new HotelInfoDTO { Hotel = r.Hotel, HotelRates = r.HotelRates.Where(hr => hr.TargetDay.Date == search.arrivalDate.Date) });


        }
    }
}
