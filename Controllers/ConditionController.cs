using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmgShoes.Data;

namespace OmgShoes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConditionController : ControllerBase
{
    private OmgShoesDbContext _dbContext;
    public ConditionController(OmgShoesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext
            .Conditions
            .ToList()
        );
    }
}