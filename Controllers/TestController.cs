using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmgShoes.Data;
using OmgShoes.Migrations;
using OmgShoes.Models;

namespace OmgShoes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private OmgShoesDbContext _dbContext;

    public TestController(OmgShoesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    // [Authorize]
    public IActionResult GetTest()
    {
        TestResponseDTO testResponseDTO = new TestResponseDTO
        {
            Response = "fetch successful"
        };

        return Ok(testResponseDTO);
    }
}