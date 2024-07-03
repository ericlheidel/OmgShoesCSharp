using System.ComponentModel.DataAnnotations.Schema;

namespace OmgShoes.Models;

public class FriendshipDTO
{
    public int Id { get; set; }
    public int InitiatorId { get; set; }
    [ForeignKey("InitiatorId")]
    public FriendDTO? Initiator { get; set; }
    public int RecipientId { get; set; }
    [ForeignKey("RecipientId")]
    public FriendDTO? Recipient { get; set; }
}