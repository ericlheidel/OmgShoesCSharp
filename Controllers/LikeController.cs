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

    [HttpDelete("{id}")]
    // [Authorize]
    public IActionResult Delete(int id)
    {
        Like likeToDelete = _dbContext.Likes.SingleOrDefault(l => l.Id == id);

        if (likeToDelete == null)
        {
            return NotFound();
        }

        _dbContext.Likes.Remove(likeToDelete);
        _dbContext.SaveChanges();

        return NoContent();
    }
}