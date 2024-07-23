using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OmgShoes.Data;
using OmgShoes.Models;
using OmgShoes.Models.DTOs;

namespace OmgShoes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private OmgShoesDbContext _dbContext;

    public UserProfileController(OmgShoesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult Get()
    {
        return Ok(_dbContext
            .UserProfiles
            .Select(up => new UserProfileDTO
            {
                Id = up.Id,
                Email = up.Email,
                Name = up.Name,
                City = up.City,
                State = up.State,
                Avatar = up.Avatar,
                Bio = up.Bio,
            }).ToList());
    }

    [HttpGet("basic")]
    [Authorize]
    public IActionResult GetBasicInfo()
    {
        return Ok(_dbContext
            .UserProfiles
            .Select(up => new UserProfileBasicDTO
            {
                Id = up.Id,
                Name = up.Name,
                City = up.City,
                State = up.State,
                Avatar = up.Avatar
            }).ToList());
    }

    [HttpGet("withroles")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetWithRoles()
    {
        return Ok(_dbContext
            .UserProfiles
            .Include(up => up.IdentityUser)
            .Select(up => new UserProfileDTO
            {
                Id = up.Id,
                Email = up.Email,
                Name = up.Name,
                City = up.City,
                State = up.State,
                Avatar = up.Avatar,
                Bio = up.Bio,
                Roles = _dbContext.UserRoles
                    .Where(ur => ur.UserId == up.IdentityUserId)
                    .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name).ToList()
            }));
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetById(int id)
    {
        UserProfile userProfile = _dbContext
            .UserProfiles
            .Where(up => up.Id == id)
            .SingleOrDefault();

        if (userProfile == null)
        {
            return NotFound();
        }

        return Ok(new UserProfileDTO
        {
            Id = userProfile.Id,
            Email = userProfile.Email,
            Name = userProfile.Name,
            City = userProfile.City,
            State = userProfile.State,
            Avatar = userProfile.Avatar,
            Bio = userProfile.Bio
        });
    }

    [HttpGet("withroles/{id}")]
    [Authorize]
    public IActionResult GetByIdWithRoles(int id)
    {
        UserProfileDTO userProfile = _dbContext
            .UserProfiles
            .Where(up => up.Id == id)
            .Include(up => up.IdentityUser)
            .Select(up => new UserProfileDTO
            {
                Id = up.Id,
                Email = up.Email,
                Name = up.Name,
                City = up.City,
                State = up.State,
                Avatar = up.Avatar,
                Bio = up.Bio,
                Roles = _dbContext.UserRoles
                    .Where(ur => ur.UserId == up.IdentityUserId)
                    .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name).ToList()
            }).SingleOrDefault();

        if (userProfile == null)
        {
            return NotFound();
        }

        return Ok(userProfile);
    }

    [HttpGet("{id}/everything")]
    [Authorize]
    public IActionResult GetByIdWithShoeCollection(int id)
    {
        UserProfileDTO userProfileDTO = _dbContext
            .UserProfiles
            .Include(up => up.IdentityUser)
            .Where(up => up.Id == id)
            .Select(up => new UserProfileDTO
            {
                Id = up.Id,
                Email = up.Email,
                Name = up.Name,
                City = up.City,
                State = up.State,
                Avatar = up.Avatar,
                Bio = up.Bio,
                UserShoes = _dbContext.UserShoes
                    .Where(us => us.UserProfileId == id)
                    .Select(us => new UserShoeDTO
                    {
                        Id = us.Id,
                        UserProfileId = us.UserProfileId,
                        ShoeId = us.ShoeId,
                        Shoe = new ShoeDTO
                        {
                            Id = us.Shoe.Id,
                            Name = us.Shoe.Name,
                            Style = us.Shoe.Style,
                            Year = us.Shoe.Year,
                            ModelNumber = us.Shoe.ModelNumber,
                            Colorway = us.Shoe.Colorway,
                            Image = us.Shoe.Image
                        },
                        ConditionId = us.ConditionId,
                        Condition = new ConditionDTO
                        {
                            Id = us.Condition.Id,
                            Description = us.Condition.Description
                        },
                        ShoeSize = us.ShoeSize,
                        Description = us.Description,
                        Likes = us.Likes.Select(l => new LikeDTO
                        {
                            Id = l.Id,
                            UserShoeId = l.UserShoeId,
                            UserProfileId = l.UserProfileId
                        }).ToList()
                    }).ToList()
            })
            .SingleOrDefault();

        if (userProfileDTO == null)
        {
            return NotFound();
        }

        return Ok(userProfileDTO);
    }

    [HttpPut("{id}")]
    [Authorize]
    public IActionResult Update(UserProfile userProfile, int id)
    {
        UserProfile userProfileToUpdate =
        _dbContext
        .UserProfiles
        .SingleOrDefault(up => up.Id == id);

        if (userProfileToUpdate == null)
        {
            return NotFound();
        }

        userProfileToUpdate.Name = userProfile.Name;
        userProfileToUpdate.City = userProfile.City;
        userProfileToUpdate.State = userProfile.State;
        userProfileToUpdate.Avatar = userProfile.Avatar;
        userProfileToUpdate.Email = userProfile.Email;
        userProfileToUpdate.Bio = userProfile.Bio;

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpPost("promote/{id}")]
    [Authorize]
    public IActionResult Promote(int id)
    {
        IdentityRole role = _dbContext.Roles.SingleOrDefault(r => r.Name == "Admin");

        string identityUserId = _dbContext.UserProfiles.SingleOrDefault(up => up.Id == id).IdentityUserId;

        _dbContext.UserRoles.Add(new IdentityUserRole<string>
        {
            RoleId = role.Id,
            UserId = identityUserId
        });

        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpPost("demote/{id}")]
    [Authorize]
    public IActionResult Demote(int id)
    {
        string identityUserId = _dbContext.UserProfiles.SingleOrDefault(up => up.Id == id).IdentityUserId;

        IdentityUserRole<string> userRoleToDemote =
                _dbContext
                .UserRoles
                .SingleOrDefault(ur => ur.UserId == identityUserId);

        if (userRoleToDemote == null)
        {
            return NotFound();
        }

        _dbContext.Remove(userRoleToDemote);
        _dbContext.SaveChanges();

        return NoContent();

    }
}