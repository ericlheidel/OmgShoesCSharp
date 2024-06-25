using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
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
    // [Authorize]
    public IActionResult Get()
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
                IsAdmin = up.IsAdmin,
                IdentityUserId = up.IdentityUserId
            }).ToList());
    }

    [HttpGet("withroles")]
    // [Authorize]
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
                IsAdmin = up.IsAdmin,
                IdentityUserId = up.IdentityUserId,
                Roles = _dbContext.UserRoles
                    .Where(ur => ur.UserId == up.IdentityUserId)
                    .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name).ToList()
            }));
    }
}