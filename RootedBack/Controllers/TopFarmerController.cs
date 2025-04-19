using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TopFarmerController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TopFarmerController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("top10")]
    public async Task<IActionResult> GetTop10Farmers()
    {
        try
        {
            var farmers = await _context.GetTop10FarmersByRatingAsync();
            return Ok(farmers);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Internal Server Error", error = ex.Message });
        }
    }
}
