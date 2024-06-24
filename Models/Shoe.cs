namespace OmgShoes.Models;

public class Shoe
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Style { get; set; }
    public int Year { get; set; }
    public string? ModelNumber { get; set; }
    public string? Colorway { get; set; }
    public Uri? Image { get; set; }
}