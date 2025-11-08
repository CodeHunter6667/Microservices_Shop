using MicroservicesShop.ProductApi.DTOs;
using MicroservicesShop.ProductApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesShop.ProductApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CategoryController(ICategoryService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await service.GetCategories();
        return Ok(categories);
    }

    [HttpGet("products")]
    public async Task<IActionResult> GetCategoriesProducts()
    {
        var categories = await service.GetCategoriesProducts();
        return Ok(categories);
    }


    [HttpGet("{id:int}", Name = "GetCategory")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        var category = await service.GetCategoryById(id);
        if (category is null) NotFound("Category not found");
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory(CategoryDTO categoryDTO)
    {
        if (categoryDTO is null) return BadRequest("Invalid data");

        var result = await service.AddCategory(categoryDTO);
        return new CreatedAtRouteResult("GetCategory", new { id = result.Id }, result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCategory(int id, CategoryDTO categoryDTO)
    {
        if (id != categoryDTO.Id || categoryDTO is null)
            return BadRequest("Invalid data");
        var existingCategory = await service.GetCategoryById(id);
        if (existingCategory is null) return NotFound("Category not found");
        await service.UpdateCategory(categoryDTO);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var existingCategory = await service.GetCategoryById(id);
        if (existingCategory is null) return NotFound("Category not found");
        await service.RemoveCategory(id);
        return NoContent();
    }
}
