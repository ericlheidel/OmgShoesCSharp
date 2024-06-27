using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OmgShoes.Data;
using OmgShoes.Models;
using OmgShoes.Models.DTOs;

namespace OmgShoes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserShoeController : ControllerBase
{
    private OmgShoesDbContext _dbContext;
    public UserShoeController(OmgShoesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet("collection/{id}")]
    // [Authorize]
    public IActionResult GetUserShoeCollection(int id)
    {
        return Ok(_dbContext
            .UserShoes
            .Include(us => us.Shoe)
            .Include(us => us.Condition)
            .OrderBy(us => us.Id)
            .Where(us => us.UserProfileId == id)
            .ToList()
        );
    }

    [HttpGet("{id}")]
    // [Authorize]
    public IActionResult GetById(int id)
    {
        UserShoe userShoe = _dbContext
            .UserShoes
            .Where(us => us.Id == id)
            .Include(us => us.Shoe)
            .Include(us => us.Condition)
            .Include(us => us.Likes)
            .Include(us => us.Comments)
            .SingleOrDefault();

        if (userShoe == null)
        {
            return NotFound();
        }

        return Ok(userShoe);
    }

    [HttpPost]
    // [Authorize]
    public IActionResult AddToCollection(UserShoe userShoe)
    {
        _dbContext.Add(userShoe);
        _dbContext.SaveChanges();

        // return NoContent();
        return Created($"api/usershoe/{userShoe.Id}", userShoe);
    }

    [HttpDelete("{id}")]
    // [Authorize]
    public IActionResult DeleteFromCollection(int id)
    {
        UserShoe userShoeToDelete = _dbContext.UserShoes.SingleOrDefault(us => us.Id == id);

        if (userShoeToDelete == null)
        {
            return NotFound();
        }

        _dbContext.Remove(userShoeToDelete);
        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpPut("{id}")]
    // [Authorize]
    public IActionResult Edit(UserShoe userShoe, int id)
    {
        UserShoe userShoeToEdit = _dbContext.UserShoes.SingleOrDefault(us => us.Id == id);

        if (userShoeToEdit == null)
        {
            return NotFound();
        }

        userShoeToEdit.UserProfileId = userShoe.UserProfileId;
        userShoeToEdit.ShoeId = userShoe.ShoeId;
        userShoeToEdit.ShoeSize = userShoe.ShoeSize;
        userShoeToEdit.ConditionId = userShoe.ConditionId;
        userShoeToEdit.Description = userShoe.Description;

        _dbContext.SaveChanges();

        return NoContent();
    }
}