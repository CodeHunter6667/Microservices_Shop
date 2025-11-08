using MicroservicesShop.ProductApi.DTOs;
using MicroservicesShop.ProductApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesShop.ProductApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductController(IProductService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await service.GetProducts();
        return Ok(products);
    }

    [HttpGet("{id:int}", Name = "GetProduct")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await service.GetProductById(id);
        if (product is null) NotFound("Product not found");
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(ProductDTO productDto)
    {
        if(productDto is null) return BadRequest("Invalid data");

        var product = await service.AddProduct(productDto);
        return new CreatedAtRouteResult("GetProduct", new { id = product.Id }, product);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateProduct(int id, ProductDTO productDto)
    {
        if (id != productDto.Id || productDto is null)
            return BadRequest("Invalid data");
        var existingProduct = await service.GetProductById(id);
        if (existingProduct is null) return NotFound("Product not found");
        await service.UpdateProduct(productDto);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var existingProduct = await service.GetProductById(id);
        if (existingProduct is null) return NotFound("Product not found");
        await service.RemoveProduct(id);
        return NoContent();
    }
}
