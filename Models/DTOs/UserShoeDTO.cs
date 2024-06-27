namespace OmgShoes.Models.DTOs;

public class UserShoeDTO
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int ShoeId { get; set; }
    public ShoeDTO? Shoe { get; set; }
    public string? ShoeSize { get; set; }
    public int ConditionId { get; set; }
    public ConditionDTO? Condition { get; set; }
    public string? Description { get; set; }
    public List<LikeDTO>? Likes { get; set; }
    public List<CommentDTO>? Comments { get; set; }
}