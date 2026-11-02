using FTELMarket.Data;
using FTELMarket.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FTELMarket.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<ProductDto>> GetAll()
    {
        return Ok(StaticData.Products);
    }

    [HttpGet("{id}")]
    public ActionResult<ProductDto> GetById(int id)
    {
        var product = StaticData.Products.FirstOrDefault(p => p.Id == id);
        return product != null ? Ok(product) : NotFound();
    }

    // POST /api/products
    [HttpPost]
    public ActionResult<ProductDto> Create([FromBody] ProductCreateRequest request)
    {
        var category = StaticData.Categories.FirstOrDefault(c => c.Id == request.CategoryId);
        if (category == null)
        {
            return BadRequest(new { message = "Catégorie inexistante." });
        }

        var nextId = StaticData.Products.Any() ? StaticData.Products.Max(p => p.Id) + 1 : 1;

        var newProduct = new ProductDto
        {
            Id = nextId,
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Stock = request.Stock,
            CategoryId = request.CategoryId,
            CreatedAt = DateTime.UtcNow,
            CategoryName = category.Name
        };

        StaticData.Products.Add(newProduct);

        return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
    }

    // PUT /api/products/{id}
    [HttpPut("{id}")]
    public ActionResult<ProductDto> Update(int id, [FromBody] ProductUpdateRequest request)
    {
        var product = StaticData.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        var category = StaticData.Categories.FirstOrDefault(c => c.Id == request.CategoryId);
        if (category == null)
        {
            return BadRequest(new { message = "Catégorie inexistante." });
        }

        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;
        product.Stock = request.Stock;
        product.CategoryId = request.CategoryId;
        product.CategoryName = category.Name;

        return Ok(product);
    }

    // DELETE /api/products/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = StaticData.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        StaticData.Products.Remove(product);

        // 204 No Content, sans corps
        return NoContent();
    }
}