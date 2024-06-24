namespace OmgShoes.Models.DTOs;

public class FriendshipDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int FriendId { get; set; }
    public string? FriendName { get; set; }
    public string? FriendAvatar { get; set; }
}