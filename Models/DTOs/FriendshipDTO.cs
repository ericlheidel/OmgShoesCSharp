using System.ComponentModel.DataAnnotations.Schema;

namespace OmgShoes.Models.DTOs;

public class FriendshipDTO
{
    public int Id { get; set; }
    public int InitiatorId { get; set; }
    [ForeignKey("InitiatorId")]
    public UserProfileFriendDTO? Initiator { get; set; }
    public int RecipientId { get; set; }
    [ForeignKey("RecipientId")]
    public UserProfileFriendDTO? Recipient { get; set; }
}