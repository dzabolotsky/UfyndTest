using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ufynd.Common.DTO;
using UFynd.Task3.Web.Implementation;
using UFynd.Task3.Web.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UFynd.Task3.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }
        // GET: api/<SearchController>
        [HttpGet]
        public Task<IEnumerable<HotelInfoDTO>> Get([FromQuery]SearchModel search) => _searchService.Search(search);


    }
}
