namespace OmgShoes.Models.DTOs;

using Microsoft.AspNetCore.Identity;

public class UserProfileDTO
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Avatar { get; set; }
    public string? Bio { get; set; }
    public bool IsAdmin { get; set; }
    public string? IdentityUserId { get; set; }
    public IdentityUser? IdentityUser { get; set; }
}