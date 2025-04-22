using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RootedBack.Data;
using SharedLibraryy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RootedBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumersController : ControllerBase
    {
        private readonly RootedDBContext _context;

        public ConsumersController(RootedDBContext context)
        {
            _context = context;
        }

        // GET: api/Consumers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consumer>>> GetConsumers()
        {
            return await _context.Consumers.ToListAsync();
        }

        // GET: api/Consumers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Consumer>> GetConsumer(int id)
        {
            var consumer = await _context.Consumers.FindAsync(id);

            if (consumer == null)
            {
                return NotFound();
            }

            return consumer;
        }

        // PUT: api/Consumers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsumer(int id, Consumer consumer)
        {
            if (id != consumer.ConsumerId)
            {
                return BadRequest();
            }

            _context.Entry(consumer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsumerExists(id))
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

        // POST: api/Consumers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Consumer>> PostConsumer(Consumer consumer)
        {
            _context.Consumers.Add(consumer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsumer", new { id = consumer.ConsumerId }, consumer);
        }

        // DELETE: api/Consumers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsumer(int id)
        {
            var consumer = await _context.Consumers.FindAsync(id);
            if (consumer == null)
            {
                return NotFound();
            }

            _context.Consumers.Remove(consumer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsumerExists(int id)
        {
            return _context.Consumers.Any(e => e.ConsumerId == id);
        }


        [HttpPost("Login")]
        public async Task<ActionResult<Consumer>> SignInConsumer(ConsumerLoginRequest request)
        {
            var consumer = await _context.Consumers
            .FirstOrDefaultAsync(C => C.Email == request.Email && C.Password == request.Password);

            if (consumer == null)
            {
                return BadRequest("البريد الإلكتروني أو كلمة المرور غير صحيحة.");
            }


            return Ok(consumer);
        }



        public class ConsumerLoginRequest
        {

            public string Email { get; set; }
            public string Password { get; set; }
        }


        //[HttpPost("ResetPassword")]
        //public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        //{
        //    if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.NewPassword))
        //        return BadRequest("البريد الإلكتروني أو كلمة المرور غير صحيحة");

        //    var Consumer = await _context.Consumers.FirstOrDefaultAsync(c => c.Email == request.Email);
        //    if (Consumer == null)
        //        return NotFound("لم يتم العثور على مستخدم بهذا البريد الإلكتروني");

        //    // يفضل تشفير كلمة المرور قبل تخزينها
        //    Consumer.Password = (request.NewPassword); // أو فقط: request.NewPassword إذا غير مشفر

        //    await _context.SaveChangesAsync();

        //    return Ok("تم تحديث كلمة المرور بنجاح");
        //}



        public class ResetPasswordRequest
        {
            public string Email { get; set; }
            public string NewPassword { get; set; }
        }



        [HttpPost("CheckEmail")]
        public async Task<ActionResult> CheckEmailExists(EmailCheckRequest request)
        {
            var Consumer = await _context.Consumers.FirstOrDefaultAsync(C => C.Email == request.Email);

            if (Consumer == null)
            {
                return NotFound("عذرًا، لم يتم العثور على بريد إلكتروني مطابق.");
            }

            return Ok("تم العثور على البريد الإلكتروني.");
        }

        public class EmailCheckRequest
        {
            public string Email { get; set; }
        }

    }
}

