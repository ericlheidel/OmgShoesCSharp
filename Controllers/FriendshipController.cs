using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OmgShoes.Data;
using OmgShoes.Models;
using OmgShoes.Models.DTOs;

namespace OmgShoes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FriendshipController : ControllerBase
{
    private OmgShoesDbContext _dbContext;
    public FriendshipController(OmgShoesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet("{initiatorId}")]
    [Authorize]
    public IActionResult GetByUser(int initiatorId)
    {
        return Ok(_dbContext
            .Friendships
            .Include(fs => fs.Initiator)
            .Include(fs => fs.Recipient)
            .Where(fs => fs.InitiatorId == initiatorId)
            .Select(fs => new FriendshipDTO
            {
                Id = fs.Id,
                InitiatorId = fs.InitiatorId,
                Initiator = fs.Initiator != null ? new UserProfileFriendDTO
                {
                    Id = fs.Initiator.Id,
                    Name = fs.Initiator.Name,
                    Avatar = fs.Initiator.Avatar
                } : null,
                RecipientId = fs.RecipientId,
                Recipient = fs.Recipient != null ? new UserProfileFriendDTO
                {
                    Id = fs.Recipient.Id,
                    Name = fs.Recipient.Name,
                    Avatar = fs.Recipient.Avatar
                } : null
            })
            .ToList());
    }

    [HttpPost]
    [Authorize]
    public IActionResult Create(Friendship friendship)
    {
        Friendship newFriendship = new Friendship
        {
            InitiatorId = friendship.InitiatorId,
            RecipientId = friendship.RecipientId
        };

        _dbContext.Friendships.Add(newFriendship);
        _dbContext.SaveChanges();

        return Created($"api/friendship/{friendship.Id}", friendship);
    }

    [HttpDelete]
    // [Authorize]
    public IActionResult Delete([FromQuery] int initiatorId, [FromQuery] int recipientId)
    {
        Friendship friendshipToDelete = _dbContext.Friendships.SingleOrDefault(fs => fs.InitiatorId == initiatorId && fs.RecipientId == recipientId);

        if (friendshipToDelete == null)
        {
            return NotFound();
        }

        _dbContext.Remove(friendshipToDelete);
        _dbContext.SaveChanges();

        return NoContent();
    }
}