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

    [HttpGet]
    // [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext
            .Shoes
            .ToList()
        );
    }

    [HttpGet("{id}")]
    // [Authorize]
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
    // [Authorize]
    public IActionResult Create(Shoe shoe)
    {
        _dbContext.Shoes.Add(shoe);
        _dbContext.SaveChanges();

        return Created($"api/shoe/{shoe.Id}", shoe);
    }
}