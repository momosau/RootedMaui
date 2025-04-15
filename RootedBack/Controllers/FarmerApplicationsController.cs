using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibraryy.Models;
using SharedLibraryy.Services;

namespace RootedBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmerApplicationsController : ControllerBase
    {
        private readonly IFarmerApplicationsService _service;

        public FarmerApplicationsController(IFarmerApplicationsService service)
        {
            _service = service;
        }

        // GET: api/FarmerApplications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FarmerApplication>>> GetAllApplications()
        {
            var applications = await _service.GetAllAsync();
            return Ok(applications);
        }

        // GET: api/FarmerApplications/pending
        [HttpGet("pending")]
        public async Task<ActionResult<IEnumerable<FarmerApplication>>> GetPendingApplications()
        {
            var pending = await _service.GetPendingAsync();
            return Ok(pending);
        }

        // GET: api/FarmerApplications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FarmerApplication>> GetById(int id)
        {
            var app = await _service.GetByIdAsync(id);
            if (app == null)
                return NotFound();
            return Ok(app);
        }

        // POST: api/FarmerApplications
        [HttpPost]
        public async Task<ActionResult<FarmerApplication>> SubmitApplication(FarmerApplication application)
        {
            var created = await _service.CreateAsync(application);
            return CreatedAtAction(nameof(GetById), new { id = created.AppilicationId }, created);
        }


        // PUT: api/FarmerApplications/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplication(int id, FarmerApplication application)
        {
            var updated = await _service.UpdateAsync(id, application);
            if (!updated) return NotFound();
            return NoContent();
        }

        // DELETE: api/FarmerApplications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }

        // POST: api/FarmerApplications/5/accept
        [HttpPost("{id}/accept")]
        public async Task<IActionResult> AcceptApplication(int id)
        {
            var acceptedFarmer = await _service.AcceptApplicationAsync(id);
            if (acceptedFarmer == null)
                return NotFound();

            return Ok(new
            {
                Message = "Farmer application accepted and added to Farmers.",
                Farmer = acceptedFarmer
            });
        }

        // DELETE: api/FarmerApplications/5/reject
        [HttpDelete("{id}/reject")]
        public async Task<IActionResult> RejectApplication(int id)
        {
            var rejected = await _service.RejectApplicationAsync(id);
            if (!rejected) return NotFound();
            return NoContent();
        }
    
    }
}
