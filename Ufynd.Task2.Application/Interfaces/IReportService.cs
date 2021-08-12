using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ufynd.Task2.Application.Interfaces
{
    public interface IReportService
    {
        Task GenerateReport(string content);

        Task GenerateReport(FileInfo file);

        Task GenerateReport(Stream stream);
    }
}
