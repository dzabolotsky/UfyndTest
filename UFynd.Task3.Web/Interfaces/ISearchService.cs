using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ufynd.Common.DTO;
using UFynd.Task3.Web.Implementation;

namespace UFynd.Task3.Web.Interfaces
{
    public interface ISearchService
    {
        Task<IEnumerable<HotelInfoDTO>> Search(SearchModel search);
    }
}
