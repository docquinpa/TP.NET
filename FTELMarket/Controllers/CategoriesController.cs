using FTELMarket.Data;
using FTELMarket.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FTELMarket.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<CategoryDto>> GetAll()
    {
        return Ok(StaticData.Categories);
    }
}