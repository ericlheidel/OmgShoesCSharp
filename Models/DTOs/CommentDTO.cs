namespace OmgShoes.Models.DTOs;

public class CommentDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int UserShoeId { get; set; }
    public string? Text { get; set; }
    public DateTime TimeStamp { get; set; }
    public bool IsEdited { get; set; }
    public UserProfileDTO? User { get; set; }
}