using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufynd.Application.Task1.DTO;

namespace Ufynd.Application.Task1.Interfaces
{
    public interface IBookingParsingService
    {
        Task<HotelDTO> Parse(Stream stream);
        Task<HotelDTO> Parse(FileInfo file);
        Task<HotelDTO> Parse(string content);

        Task<HotelDTO> ParseByPath(string path);
    }
}
