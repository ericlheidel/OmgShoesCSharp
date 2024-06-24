namespace OmgShoes.Models;

public class UserShoe
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ShoeId { get; set; }
    public int ShoeSize { get; set; }
    public int ConditionId { get; set; }
    public string? Description { get; set; }
}