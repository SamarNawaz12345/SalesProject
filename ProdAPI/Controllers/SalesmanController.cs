using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Model;

namespace ProdAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesmanController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SalesmanController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Salesman
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salesman>>> GetSalesmen()
        {
            return await _context.Salesmens.ToListAsync();
        }

        // GET: api/Salesman/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Salesman>> GetSalesman(int id)
        {
            var salesman = await _context.Salesmens.FindAsync(id);

            if (salesman == null)
            {
                return NotFound();
            }

            return salesman;
        }

        // POST: api/Salesman
        [HttpPost]
        public async Task<ActionResult<Salesman>> PostSalesman(Salesman salesman)
        {
            _context.Salesmens.Add(salesman);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSalesman), new { id = salesman.SalesmanId }, salesman);
        }

        // PUT: api/Salesman/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesman(int id, Salesman salesman)
        {
            if (id != salesman.SalesmanId)
            {
                return BadRequest();
            }

            _context.Entry(salesman).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesmanExists(id))
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

        // DELETE: api/Salesman/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesman(int id)
        {
            var salesman = await _context.Salesmens.FindAsync(id);
            if (salesman == null)
            {
                return NotFound();
            }

            _context.Salesmens.Remove(salesman);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalesmanExists(int id)
        {
            return _context.Salesmens.Any(e => e.SalesmanId == id);
        }
    }
}

