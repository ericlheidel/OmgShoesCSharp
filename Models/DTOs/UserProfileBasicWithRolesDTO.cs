namespace OmgShoes.Models.DTOs;

public class UserProfileBasicWithRolesDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Avatar { get; set; }
    public List<string>? Roles { get; set; }

}