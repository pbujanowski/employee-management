using EmployeeManagement.API.Data;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DutiesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IDutyService<Duty> service;

        public DutiesController(ApplicationDbContext context, IDutyService<Duty> service)
        {
            this.context = context;
            this.service = service;
        }

        // GET: api/Duties
        [HttpGet]
        public async Task<ActionResult<string>> GetDuties()
        {
            var duties = await service.GetAllAsync().ConfigureAwait(false);
            return JsonConvert.SerializeObject(duties);
        }

        // GET: api/Duties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetDutiesByEmployeeId(int employeeId)
        {
            var duties = await service.GetAllByEmployeeIdAsync(employeeId).ConfigureAwait(false);
            return JsonConvert.SerializeObject(duties);
        }

        // PUT: api/Duties/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDuty(int id, [FromBody] Duty duty)
        {
            if (id != duty.Id)
            {
                return BadRequest();
            }

            context.Entry(duty).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DutyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Duties
        [HttpPost]
        public async Task<ActionResult<Duty>> PostDuty([FromBody] Duty duty)
        {
            context.Duties.Add(duty);
            await context.SaveChangesAsync().ConfigureAwait(false);

            return CreatedAtAction("GetDuty", new { id = duty.Id }, duty);
        }

        // DELETE: api/Duties/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Duty>> DeleteDuty(int id)
        {
            var duty = await context.Duties.FindAsync(id).ConfigureAwait(false);
            if (duty == null)
            {
                return NotFound();
            }

            context.Duties.Remove(duty);
            await context.SaveChangesAsync().ConfigureAwait(false);

            return duty;
        }

        private bool DutyExists(int id)
        {
            return context.Duties.Any(e => e.Id == id);
        }
    }
}