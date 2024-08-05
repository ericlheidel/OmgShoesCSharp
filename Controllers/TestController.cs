using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmgShoes.Data;
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

    [HttpGet("shoe")]
    // [Authorize]
    public IActionResult ShoeTest()
    {
        try
        {
            Shoe shoe = _dbContext
            .Shoes
            .SingleOrDefault(s => s.Id == 1);

            if (shoe == null)
            {
                return NotFound();
            }
            return Ok(shoe);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
        }


    }

    [HttpGet("comment")]
    // [Authorize]
    public IActionResult CommentTest()
    {
        try
        {
            Comment comment = _dbContext
                .Comments
                .SingleOrDefault(c => c.Id == 1);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
        }
    }
}

