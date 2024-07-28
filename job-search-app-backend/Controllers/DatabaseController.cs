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
}