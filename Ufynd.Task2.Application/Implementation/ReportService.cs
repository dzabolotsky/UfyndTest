using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Ufynd.Common.DTO;
using Ufynd.Common.Interfaces;
using Ufynd.Task2.Application.DTO;
using Ufynd.Task2.Application.Enums;
using Ufynd.Task2.Application.Interfaces;

[assembly: InternalsVisibleTo("Ufynd.Task2.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2, PublicKey=0024000004800000940000000602000000240000525341310004000001000100c547cac37abd99c8db225ef2f6c8a3602f3b3606cc9891605d02baa56104f4cfc0734aa39b93bf7852f7d9266654753cc297e7d2edfe0bac1cdcf9f717241550e0a7b191195b7667bb4f64bcb8e2121380fd1d9d46ad2d92d2d15605093924cceaf74c4861eff62abf69b9291ed0a340e113be11e6a7d3113e92484cf7045cc7")]
namespace Ufynd.Task2.Application.Implementation
{
    internal class ReportService : IReportService
    {
        private readonly ILogger<ReportService> _logger;
        private readonly IXlsProcessingService _xlsProcessingService;
        private readonly IMapper _mapper;
        private readonly IDataService _dataService;
        private readonly AppSettings _appSettings;

        public ReportService(ILogger<ReportService> logger, IXlsProcessingService xlsProcessingService, IMapper mapper, IDataService dataService, AppSettings appSettings)
        {
            _logger = logger;
            _xlsProcessingService = xlsProcessingService;
            _mapper = mapper;
            _dataService = dataService;
            _appSettings = appSettings;
        }

        private IEnumerable<HeaderColumn> GetColumns()
        {
            var columns = new List<HeaderColumn>();
            columns.Add(new HeaderColumn("ArrivalDate", "Arrival Date", 40, AlighmentEnum.Center));
            columns.Add(new HeaderColumn("DepartureDate", "Departure Date", 40, AlighmentEnum.Center));
            columns.Add(new HeaderColumn("Price", "Price", 40, AlighmentEnum.Center));
            columns.Add(new HeaderColumn("Currency", "Currency", 10, AlighmentEnum.Center));
            columns.Add(new HeaderColumn("RateName", "Rate Name", -1, AlighmentEnum.Left));
            columns.Add(new HeaderColumn("Adults", "Adults", 20, AlighmentEnum.Right));
            columns.Add(new HeaderColumn("IsBreakfastIncluded", "Breakfast_Included", 20, AlighmentEnum.Right));
            return columns;
        }
        public async Task GenerateReport(Stream stream)
        {
            try
            {
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var content = await reader.ReadToEndAsync();
                    await GenerateReport(content);
                   
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }

        }

        public async Task GenerateReport(FileInfo file)
        {
            try
            {
                using (StreamReader reader = new StreamReader(file.FullName, Encoding.UTF8))
                {
                    var content = await reader.ReadToEndAsync();
                    await GenerateReport(content);
                   
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }

        }

        public async Task GenerateReport(string content)
        {
            try
            {
                _logger.LogDebug("getting data");
                var data = await _dataService.GetData<HotelInfoDTO>(content);
                _logger.LogDebug("mapping data");
                var items = data.HotelRates.Select(r => _mapper.Map<HotelRateDTO, ReportDTO>(r)).OrderBy(r => r.ArrivalDate).ToList();
                _logger.LogDebug("creating columns");
                var columns = GetColumns();
                _logger.LogDebug($"drop folder {_appSettings.OutputFolderPath} if exists");
                if (!Directory.Exists(_appSettings.OutputFolderPath))
                    Directory.CreateDirectory(_appSettings.OutputFolderPath);
                _logger.LogDebug("generate xlsx");
                await _xlsProcessingService.CreateDocument(columns, items, "Task 2.Reporting", Path.Combine(_appSettings.OutputFolderPath, $"result_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.xlsx"));

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }


    }
}
