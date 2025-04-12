using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RootedBack.Data;
using SharedLibraryy.Models;

namespace RootedBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerApplicationsController : ControllerBase
    {
        private readonly RootedDBContext _context;

        public FarmerApplicationsController(RootedDBContext context)
        {
            _context = context;
        }

        // GET: api/FarmerApplications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FarmerApplication>>> GetFarmerApplications()
        {
            return await _context.FarmerApplications.ToListAsync();
        }

        // GET: api/FarmerApplications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FarmerApplication>> GetFarmerApplication(int id)
        {
            var farmerApplication = await _context.FarmerApplications.FindAsync(id);

            if (farmerApplication == null)
            {
                return NotFound();
            }

            return farmerApplication;
        }

        // PUT: api/FarmerApplications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFarmerApplication(int id, FarmerApplication farmerApplication)
        {
            if (id != farmerApplication.AppilicationId)
            {
                return BadRequest();
            }

            _context.Entry(farmerApplication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmerApplicationExists(id))
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

        // POST: api/FarmerApplications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FarmerApplication>> PostFarmerApplication(FarmerApplication farmerApplication)
        {
            _context.FarmerApplications.Add(farmerApplication);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFarmerApplication", new { id = farmerApplication.AppilicationId }, farmerApplication);
        }

        // DELETE: api/FarmerApplications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFarmerApplication(int id)
        {
            var farmerApplication = await _context.FarmerApplications.FindAsync(id);
            if (farmerApplication == null)
            {
                return NotFound();
            }

            _context.FarmerApplications.Remove(farmerApplication);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FarmerApplicationExists(int id)
        {
            return _context.FarmerApplications.Any(e => e.AppilicationId == id);
        }
    }
}
