namespace OmgShoes.Models;

public class Comment
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public UserProfile? User { get; set; }
    public int UserShoeId { get; set; }
    public string? Text { get; set; }
    public DateTime TimeStamp { get; set; }
    public bool IsEdited { get; set; }
}