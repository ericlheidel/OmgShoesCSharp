namespace OmgShoes.Models.DTOs;

public class UserShoeDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ShoeId { get; set; }
    public string? Style { get; set; }
    public string? ShoeSize { get; set; }
    public int ConditionId { get; set; }
    public string? Description { get; set; }
}