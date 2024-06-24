namespace OmgShoes.Models;

public class Friendship
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int FriendId { get; set; }
    public string? FriendName { get; set; }
    public Uri? FriendAvatar { get; set; }
}