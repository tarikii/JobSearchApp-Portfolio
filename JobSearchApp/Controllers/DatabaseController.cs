using JobSearchApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobSearchApp.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DatabaseController : ControllerBase
{
    private readonly IDbContextFactory<ApplicationDbContext> _context;

    public DatabaseController(IDbContextFactory<ApplicationDbContext> context)
    {
        _context = context;
    }

    [HttpGet("test-connection")]
    public async Task<IActionResult> TestConnection(CancellationToken token = default)
    {
        var result = await _context.CreateDbContextAsync(token);
        var r = await result.Database.CanConnectAsync(token);
        return Ok(r);
    }
    
    [HttpPost("revert")]
    public IActionResult RevertDatabase()
    {
        try
        {
            //DbInitializer.Revert(_context);
            return Ok("Database reverted successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while reverting the database: {ex.Message}");
        }
    }
}