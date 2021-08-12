using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufynd.Task2.Application.Implementation;

namespace Ufynd.Task2.Application.Interfaces
{
    public interface IXlsProcessingService
    {
        Task CreateDocument<T>(IEnumerable<HeaderColumn> columns, IEnumerable<T> items, string title, string path) where T : class;
    }
}
