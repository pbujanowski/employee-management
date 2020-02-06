using EmployeeManagement.API.Data;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ICityService<City> cityService;

        public CitiesController(ApplicationDbContext dbContext, ICityService<City> cityService)
        {
            this.dbContext = dbContext;
            this.cityService = cityService;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            var cities = await cityService.GetAllAsync().ConfigureAwait(false);
            return JsonConvert.SerializeObject(cities);
        }

        // GET: api/Cities/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cities
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Cities/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}