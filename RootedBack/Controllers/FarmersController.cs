using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RootedBack.Data;
using SharedLibraryy.Models;

namespace RootedBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmersController : ControllerBase
    {
        private readonly RootedDBContext _context;

        public FarmersController(RootedDBContext context)
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
        [HttpPost("upload-certificate")]
        public async Task<IActionResult> UploadCertificate(IFormFile file, int farmerId)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is empty.");

            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/certificates");
            Directory.CreateDirectory(uploadsFolder);

            string fileName = $"farmer_{farmerId}.pdf";
            string filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            string relativePath = $"/certificates/{fileName}";

            using (var connection = new SqlConnection("DefaultConnection"))
            {
                string query = "UPDATE Farmer SET CertificatePath = @FilePath WHERE FarmerID = @FarmerID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FilePath", relativePath);
                    command.Parameters.AddWithValue("@FarmerID", farmerId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            return Ok(new { Message = "File uploaded successfully!", Path = relativePath });
        }



        [HttpPost("Login")]
        public async Task<ActionResult<Farmer>> SignInFarmer(FarmerLoginRequest request)
        {
            var farmer = await _context.Farmers
                .FirstOrDefaultAsync(f => f.Email == request.Email && f.Password == request.Password);

            if (farmer == null)
            {
                return BadRequest("البريد الإلكتروني أو كلمة المرور غير صحيحة.");
            }

            if (farmer.VerificationStatus != true)
            {
                return Unauthorized("ليس لديك صلاحية للدخول. يرجى الانتظار حتى تتم الموافقة عليك من قبل الإدارة.");
            }

            return Ok(farmer);
        }

        public class FarmerLoginRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

    }
}