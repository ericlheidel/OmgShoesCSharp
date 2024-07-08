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



    [HttpGet("{userId}")]
    [Authorize]
    public IActionResult GetByUserId(int userId)
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
        // .Select(fs => new FriendshipDTO
        // {
        //     Id = fs.Id,
        //     InitiatorId = fs.InitiatorId,
        //     Initiator = fs.Initiator != null ? new UserProfileFriendDTO
        //     {
        //         Id = fs.Initiator.Id,
        //         Name = fs.Initiator.Name,
        //         Avatar = fs.Initiator.Avatar
        //     } : null,
        //     RecipientId = fs.RecipientId,
        //     Recipient = fs.Recipient != null ? new UserProfileFriendDTO
        //     {
        //         Id = fs.Recipient.Id,
        //         Name = fs.Recipient.Name,
        //         Avatar = fs.Recipient.Avatar
        //     } : null
        // }).ToList();

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
        // .Select(fs => new FriendshipDTO
        // {
        //     Id = fs.Id,
        //     InitiatorId = fs.InitiatorId,
        //     Initiator = fs.Initiator != null ? new UserProfileFriendDTO
        //     {
        //         Id = fs.Initiator.Id,
        //         Name = fs.Initiator.Name,
        //         Avatar = fs.Initiator.Avatar
        //     } : null,
        //     RecipientId = fs.RecipientId,
        //     Recipient = fs.Recipient != null ? new UserProfileFriendDTO
        //     {
        //         Id = fs.Recipient.Id,
        //         Name = fs.Recipient.Name,
        //         Avatar = fs.Recipient.Avatar
        //     } : null
        // }).ToList();

        var friends = friendshipsByInitiator
            .Union(friendshipsByRecipient)
            .ToList();

        return Ok(friends.OrderBy(f => f.Name));
    }



    [HttpGet("initiator/{initiatorId}")]
    [Authorize]
    public IActionResult GetByInitiator(int initiatorId)
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

    [HttpGet("recipient/{recipientId}")]
    [Authorize]
    public IActionResult GetByRecipient(int recipientId)
    {
        return Ok(_dbContext
            .Friendships
            .Include(fs => fs.Initiator)
            .Include(fs => fs.Recipient)
            .Where(fs => fs.RecipientId == recipientId)
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
    [Authorize]
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