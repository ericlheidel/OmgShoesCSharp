using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    [Authorize]
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

    [HttpDelete]
    [Authorize]
    public IActionResult Delete([FromQuery] int userShoeId, [FromQuery] int userId)
    {
        Like likeToDelete = _dbContext.Likes.SingleOrDefault(l => l.UserShoeId == userShoeId && l.UserProfileId == userId);

        if (likeToDelete == null)
        {
            return NotFound();
        }

        _dbContext.Likes.Remove(likeToDelete);
        _dbContext.SaveChanges();

        return NoContent();
    }
}