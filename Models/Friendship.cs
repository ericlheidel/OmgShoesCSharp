namespace OmgShoes.Models;

public class Friendship
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public int FriendId { get; set; }
    public string? FriendName { get; set; }
    public string? FriendAvatar { get; set; }
}