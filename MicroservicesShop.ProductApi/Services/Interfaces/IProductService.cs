using MicroservicesShop.ProductApi.DTOs;

namespace MicroservicesShop.ProductApi.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetProducts();
    Task<ProductDTO> GetProductById(int id);
    Task<ProductDTO> AddProduct(ProductDTO productDto);
    Task<ProductDTO> UpdateProduct(ProductDTO productDto);
    Task<bool> RemoveProduct(int id);
}
