using JobSearchApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobSearchApp.Web.Controllers;

[Route("[controller]")]
[ApiController]
public class HealthCheckController : ControllerBase
{
    private readonly IDbContextFactory<ApplicationDbContext> _context;

    public HealthCheckController(IDbContextFactory<ApplicationDbContext> context)
    {
        _context = context;
    }

    [HttpGet("")]
    public async Task<IActionResult> TestConnection(CancellationToken token = default)
    {
        var result = await _context.CreateDbContextAsync(token);
        var r = await result.Database.CanConnectAsync(token);
        var x = await result.Permissions.ToListAsync(cancellationToken: token);
        return Ok(r);
    }
}