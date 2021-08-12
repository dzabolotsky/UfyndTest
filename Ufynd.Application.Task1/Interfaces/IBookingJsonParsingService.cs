using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufynd.Application.Task1.DTO;

namespace Ufynd.Application.Task1.Interfaces
{
    public interface IBookingJsonParsingService
    {
        Task<string> Parse(Stream stream);
        Task<string> Parse(FileInfo file);
        Task<string> Parse(string content);
    }
}
