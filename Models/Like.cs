namespace OmgShoes.Models;

public class Like
{
    public int Id { get; set; }
    public int UserShoeId { get; set; }
    public int UserProfileId { get; set; }
}