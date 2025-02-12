using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RootedBackend.Models;

namespace RootedBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmersController : ControllerBase
    {
        private readonly RootedDbContext _context;

        public FarmersController(RootedDbContext context)
        {
            _context = context;
        }

        // GET: api/Farmers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Farmer>>> GetFarmers()
        {
            return await _context.Farmers.ToListAsync();
        }

        // GET: api/Farmers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Farmer>> GetFarmer(int id)
        {
            var farmer = await _context.Farmers.FindAsync(id);

            if (farmer == null)
            {
                return NotFound();
            }

            return farmer;
        }

        // PUT: api/Farmers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFarmer(int id, Farmer farmer)
        {
            if (id != farmer.FarmerId)
            {
                return BadRequest();
            }

            _context.Entry(farmer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmerExists(id))
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

        // POST: api/Farmers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Farmer>> PostFarmer(Farmer farmer)
        {
            _context.Farmers.Add(farmer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFarmer", new { id = farmer.FarmerId }, farmer);
        }

        // DELETE: api/Farmers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFarmer(int id)
        {
            var farmer = await _context.Farmers.FindAsync(id);
            if (farmer == null)
            {
                return NotFound();
            }

            _context.Farmers.Remove(farmer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FarmerExists(int id)
        {
            return _context.Farmers.Any(e => e.FarmerId == id);
        }
    }
}
