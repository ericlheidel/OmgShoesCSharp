using System.ComponentModel.DataAnnotations.Schema;

namespace OmgShoes.Models;

public class UserShoe
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int ShoeId { get; set; }
    public Shoe? Shoe { get; set; }
    public string? ShoeSize { get; set; }
    public int ConditionId { get; set; }
    public Condition? Condition { get; set; }
    public string? Description { get; set; }
    public List<Like>? Likes { get; set; }
    public List<Comment>? Comments { get; set; }
    [NotMapped]
    public bool IsLikedByCurrentUser { get; set; }
}