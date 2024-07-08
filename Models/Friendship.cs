using System.ComponentModel.DataAnnotations.Schema;

namespace OmgShoes.Models;

public class Friendship
{
    public int Id { get; set; }
    public int InitiatorId { get; set; }
    [ForeignKey("InitiatorId")]
    public UserProfile? Initiator { get; set; }
    public int RecipientId { get; set; }
    [ForeignKey("RecipientId")]
    public UserProfile? Recipient { get; set; }
}