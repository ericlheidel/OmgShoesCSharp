using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmgShoes.Data;
using OmgShoes.Models;

namespace OmgShoes.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShoeController : ControllerBase
{
    private OmgShoesDbContext _dbContext;

    public ShoeController(OmgShoesDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetById(int id)
    {
        Shoe shoe = _dbContext
            .Shoes
            .SingleOrDefault(s => s.Id == id);

        if (shoe == null)
        {
            return NotFound();
        }

        return Ok(shoe);
    }

    [HttpPost]
    [Authorize]
    public IActionResult Create(Shoe shoe)
    {
        _dbContext.Shoes.Add(shoe);
        _dbContext.SaveChanges();

        return Created($"api/shoe/{shoe.Id}", shoe);
    }

    [HttpGet("search")]
    [Authorize]
    public IActionResult GetBySearch([FromQuery] string? searchTerm = null, [FromQuery] int? filterYear = null)
    {
        var queriedShoes = _dbContext.Shoes.AsQueryable();


        if (searchTerm != null)
        {
            searchTerm = searchTerm.ToLower();
            queriedShoes = queriedShoes
                            .Where(s => s.Name.ToLower().Contains(searchTerm) ||
                                        s.ModelNumber.Contains(searchTerm) ||
                                        s.Colorway.ToLower().Contains(searchTerm));
        }

        if (filterYear != null)
        {
            queriedShoes = queriedShoes.Where(s => s.Year.Equals(filterYear));
        }

        var filteredShoes = queriedShoes
                            .OrderBy(s => s.Year)
                            .ThenBy(s => s.Name)
                            .ToList();

        return Ok(filteredShoes);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult Delete(int id)
    {
        Shoe shoeToDelete = _dbContext.Shoes.SingleOrDefault(s => s.Id == id);

        _dbContext.Remove(shoeToDelete);
        _dbContext.SaveChanges();

        return NoContent();
    }
}