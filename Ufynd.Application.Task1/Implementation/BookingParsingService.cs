using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Ufynd.Application.Task1.DTO;
using Ufynd.Application.Task1.Interfaces;

[assembly: InternalsVisibleTo("Ufynd.Task1.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2, PublicKey=0024000004800000940000000602000000240000525341310004000001000100c547cac37abd99c8db225ef2f6c8a3602f3b3606cc9891605d02baa56104f4cfc0734aa39b93bf7852f7d9266654753cc297e7d2edfe0bac1cdcf9f717241550e0a7b191195b7667bb4f64bcb8e2121380fd1d9d46ad2d92d2d15605093924cceaf74c4861eff62abf69b9291ed0a340e113be11e6a7d3113e92484cf7045cc7")]
namespace Ufynd.Application.Task1.Implementation
{
    internal class BookingParsingService : IBookingParsingService
    {
        private readonly ILogger<BookingParsingService> _logger;

        public BookingParsingService(ILogger<BookingParsingService> logger)
        {
            _logger = logger;
        }

        public async Task<HotelDTO> Parse(Stream stream)
        {
            try
            {
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var content = await reader.ReadToEndAsync();
                    var result = await Parse(content);
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }

        }

        public async Task<HotelDTO> ParseByPath(string path)
        {
            try
            {
                var file = new FileInfo(path);
                return await Parse(file);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }

        }

        public async Task<HotelDTO> Parse(FileInfo file)
        {
            try
            {
                using (StreamReader reader = new StreamReader(file.FullName, Encoding.UTF8))
                {
                    var content = await reader.ReadToEndAsync();
                    var result = await Parse(content);
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }

        }

        public Task<HotelDTO> Parse(string content)
        {
            try
            {
                var doc = new HtmlDocument();
                doc.LoadHtml(content);
                var htmpExtractService = new HtmlExtractTagService(doc);
                return Task.FromResult(HotelDTO.Create(doc, htmpExtractService));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }


        }
    }
}
