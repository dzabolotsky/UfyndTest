using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Ufynd.Common.DTO;
using Ufynd.Common.Interfaces;

[assembly: InternalsVisibleTo("Ufynd.Task2.Tests")]
namespace Ufynd.Common.Implementation
{

    public class DataService : IDataService
    {
        public Task<T> GetData<T>(string content) where T:class => Task.FromResult(JsonConvert.DeserializeObject<T>(content));
    }
}
