using JobSearchApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DatabaseController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DatabaseController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("test-connection")]
    public async Task<IActionResult> TestConnection()
    {
        var result = await _context.TestConnectionAsync();
        return Ok(result);
    }
    
    [HttpPost("revert")]
    public IActionResult RevertDatabase()
    {
        try
        {
            DbInitializer.Revert(_context);
            return Ok("Database reverted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while reverting the database: {ex.Message}");
        }
    }
}