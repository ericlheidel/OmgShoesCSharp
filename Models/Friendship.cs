using System.ComponentModel.DataAnnotations.Schema;

namespace OmgShoes.Models;

public class Friendship
{
    public int Id { get; set; }
    public int InitiatorId { get; set; }
    [ForeignKey("InitiatorId")]
    public Friend? Initiator { get; set; }
    public int RecipientId { get; set; }
    [ForeignKey("RecipientId")]
    public Friend? Recipient { get; set; }
}