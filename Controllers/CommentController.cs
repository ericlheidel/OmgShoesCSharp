using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OmgShoes.Data;
using OmgShoes.Models;

namespace OmgShoes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private OmgShoesDbContext _dbContext;
    public CommentController(OmgShoesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet("{id}")]
    // [Authorize]
    public IActionResult GetByUserShoeId(int id)
    {
        return Ok(_dbContext
            .Comments
            .Where(c => c.UserShoeId == id)
            .ToList()
        );
    }
}

//√  get comments by userShoeId
//!  add comments
//!  remove comment by id
//!  update comment