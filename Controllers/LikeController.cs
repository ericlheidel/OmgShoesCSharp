using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OmgShoes.Data;
using OmgShoes.Models;

namespace OmgShoes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LikeController : ControllerBase
{
    private OmgShoesDbContext _dbContext;
    public LikeController(OmgShoesDbContext context)
    {
        _dbContext = context;
    }

    [HttpPost]
    // [Authorize]
    public IActionResult Post(Like like)
    {
        Like newLike = new Like
        {
            UserProfileId = like.UserProfileId,
            UserShoeId = like.UserShoeId
        };

        _dbContext.Likes.Add(newLike);
        _dbContext.SaveChanges();

        return NoContent();
    }
}

//√  post like
//!  remove by id