using FTELMarket.DTOs;
using FTELMarket.Infrastructure;
using FTELMarket.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FTELMarket.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly FtelMarketDbContext _context;

    public ProductsController(FtelMarketDbContext context)
    {
        _context = context;
    }

    // GET /api/products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
    {
        var products = await _context.Products
            .AsNoTracking()
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock,
                CategoryId = p.CategoryId,
                CreatedAt = p.CreatedAt,
                CategoryName = p.Category.Name
            })
            .ToListAsync();

        return Ok(products);
    }

    // GET /api/products/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetById(int id)
    {
        var product = await _context.Products
            .AsNoTracking()
            .Where(p => p.Id == id)
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock,
                CategoryId = p.CategoryId,
                CreatedAt = p.CreatedAt,
                CategoryName = p.Category.Name
            })
            .FirstOrDefaultAsync();

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    // POST /api/products
    [HttpPost]
    public async Task<ActionResult<ProductDto>> Create([FromBody] ProductCreateRequest request)
    {
        var category = await _context.Categories.FindAsync(request.CategoryId);
        if (category == null)
        {
            return BadRequest(new { message = "Catégorie inexistante." });
        }

        var newProduct = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Stock = request.Stock,
            CategoryId = request.CategoryId,
            CreatedAt = DateTime.UtcNow
        };

        _context.Products.Add(newProduct);
        await _context.SaveChangesAsync();

        var responseDto = new ProductDto
        {
            Id = newProduct.Id,
            Name = newProduct.Name,
            Description = newProduct.Description,
            Price = newProduct.Price,
            Stock = newProduct.Stock,
            CategoryId = newProduct.CategoryId,
            CreatedAt = newProduct.CreatedAt,
            CategoryName = category.Name
        };

        return CreatedAtAction(nameof(GetById), new { id = responseDto.Id }, responseDto);
    }

    // PUT /api/products/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult<ProductDto>> Update(int id, [FromBody] ProductUpdateRequest request)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        var category = await _context.Categories.FindAsync(request.CategoryId);
        if (category == null)
        {
            return BadRequest(new { message = "Catégorie inexistante." });
        }

        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;
        product.Stock = request.Stock;
        product.CategoryId = request.CategoryId;

        await _context.SaveChangesAsync();

        var responseDto = new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            CategoryId = product.CategoryId,
            CreatedAt = product.CreatedAt,
            CategoryName = category.Name
        };

        return Ok(responseDto);
    }

    // DELETE /api/products/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
