using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public IActionResult GetByUserShoeId(int id)
    {
        return Ok(_dbContext
            .Comments
            .Where(c => c.UserShoeId == id)
            .Include(c => c.User)
            .OrderByDescending(c => c.TimeStamp)
            .ToList()
        );
    }

    [HttpPost]
    [Authorize]
    public IActionResult Post(Comment comment)
    {
        Comment newComment = new Comment
        {
            UserProfileId = comment.UserProfileId,
            UserShoeId = comment.UserShoeId,
            Text = comment.Text,
            TimeStamp = DateTime.Now,
            IsEdited = false
        };


        _dbContext.Comments.Add(newComment);
        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult Delete(int id)
    {
        Comment commentToDelete = _dbContext.Comments.SingleOrDefault(c => c.Id == id);

        if (commentToDelete == null)
        {
            return NotFound();
        }

        _dbContext.Remove(commentToDelete);
        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpPut("{id}")]
    [Authorize]
    public IActionResult Edit(Comment comment, int id)
    {
        Comment commentToEdit = _dbContext.Comments.SingleOrDefault(c => c.Id == id);

        if (commentToEdit == null)
        {
            return NotFound();
        }

        commentToEdit.UserProfileId = comment.UserProfileId;
        commentToEdit.UserShoeId = comment.UserShoeId;
        commentToEdit.Text = comment.Text;
        commentToEdit.TimeStamp = DateTime.Now;
        commentToEdit.IsEdited = true;

        _dbContext.SaveChanges();

        return NoContent();
    }
}