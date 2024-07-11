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

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext
            .Friendships
            .Include(fs => fs.Initiator)
            .Include(fs => fs.Recipient)
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
            }).ToList());

    }

    [HttpGet("{userId}")]
    [Authorize]
    public IActionResult GetFriendsByUserId(int userId)
    //! This Get returns a users friends
    {
        var friendshipsByInitiator = _dbContext
            .Friendships
            .Include(fs => fs.Initiator)
            .Include(fs => fs.Recipient)
            .Where(fs => fs.InitiatorId == userId)
            .Select(fs => new FriendDTO
            {
                UserId = fs.Recipient.Id,
                Name = fs.Recipient.Name,
                Avatar = fs.Recipient.Avatar
            }).ToList();

        var friendshipsByRecipient = _dbContext
            .Friendships
            .Include(fs => fs.Initiator)
            .Include(fs => fs.Recipient)
            .Where(fs => fs.RecipientId == userId)
            .Select(fs => new FriendDTO
            {
                UserId = fs.Initiator.Id,
                Name = fs.Initiator.Name,
                Avatar = fs.Initiator.Avatar
            }).ToList();

        var friends = friendshipsByInitiator
            .Union(friendshipsByRecipient)
            .ToList();

        return Ok(friends.OrderBy(f => f.Name));
    }

    [HttpPost]
    [Authorize]
    public IActionResult Create(Friendship friendship)
    {
        Friendship friendshipToCheckFor = _dbContext.Friendships.SingleOrDefault(fs => fs.InitiatorId == friendship.InitiatorId && fs.RecipientId == friendship.RecipientId || fs.InitiatorId == friendship.RecipientId && fs.RecipientId == friendship.InitiatorId);

        if (friendshipToCheckFor == null)
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

        else
        {
            return BadRequest(new { message = "Friendship already exists" });
        }

    }

    [HttpDelete("{idOne}/{idTwo}")]
    [Authorize]
    public IActionResult Delete(int idOne, int idTwo)
    {
        Friendship friendshipToDelete = _dbContext.Friendships.SingleOrDefault(fs => fs.InitiatorId == idOne && fs.RecipientId == idTwo);

        if (friendshipToDelete == null)
        {
            Friendship friendshipToDeleteReverse = _dbContext.Friendships.SingleOrDefault(fs => fs.InitiatorId == idTwo && fs.RecipientId == idOne);

            if (friendshipToDeleteReverse == null)
            {
                return NotFound();
            }
            else
            {
                _dbContext.Remove(friendshipToDeleteReverse);
                _dbContext.SaveChanges();
            }
        }
        else
        {
            _dbContext.Remove(friendshipToDelete);
            _dbContext.SaveChanges();
        }



        return NoContent();
    }

    [HttpGet("isfriend")]
    [Authorize]
    public IActionResult IsFriend([FromQuery] int loggedInUserId, [FromQuery] int nonLoggedInUserId)
    {
        Friendship friendship = _dbContext.Friendships
            .SingleOrDefault(f => f.InitiatorId == loggedInUserId
                                && f.RecipientId == nonLoggedInUserId
                                || f.InitiatorId == nonLoggedInUserId
                                && f.RecipientId == loggedInUserId);

        if (friendship == null)
        {
            return Ok(new { status = "not friends" });
        }

        return Ok(new { status = "friends" });
    }
}