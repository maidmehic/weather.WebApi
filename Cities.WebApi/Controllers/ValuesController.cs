using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Cities.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Cities.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public  ActionResult<IEnumerable<City>> Get(int page=1, int perPage=100, string name="")
        {
            List<City> cities = Program.Cities.Where(x=>x.name.ToLower().StartsWith(name.ToLower())).ToList();

            int start = (page - 1) * perPage;
            List<City> returnCities= cities.Skip(start).Take(perPage).ToList();

            if (returnCities.Count > 0)
                return Ok(returnCities.OrderBy(x=>x.name).ToList());
            else
                return NotFound();
        }
    }
}
