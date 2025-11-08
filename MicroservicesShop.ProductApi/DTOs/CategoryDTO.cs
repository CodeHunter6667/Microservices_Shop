using MicroservicesShop.ProductApi.Models;

namespace MicroservicesShop.ProductApi.DTOs;

public class CategoryDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Product> Products { get; set; } = [];
}
