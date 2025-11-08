using MicroservicesShop.ProductApi.DTOs;
using MicroservicesShop.ProductApi.Extensions;
using MicroservicesShop.ProductApi.Repository.Interfaces;
using MicroservicesShop.ProductApi.Services.Interfaces;

namespace MicroservicesShop.ProductApi.Services;

public class ProductService(IProductRepository repository) : IProductService
{
    public async Task<ProductDTO> AddProduct(ProductDTO productDto)
    {
        var product = productDto.MapToProduct();
        var addedProduct = await repository.Create(product);
        return addedProduct.MapToDTO();
    }

    public async Task<ProductDTO> GetProductById(int id)
    {
        var product = await repository.GetById(id);
        return product.MapToDTO();
    }

    public async Task<IEnumerable<ProductDTO>> GetProducts()
    {
        var products = await repository.GetAll();
        var productsDto = products.Select(p => p.MapToDTO());
        return productsDto;
    }

    public async Task<bool> RemoveProduct(int id)
    {
        var result = await repository.Delete(id);
        return result;
    }

    public async Task<ProductDTO> UpdateProduct(ProductDTO productDto)
    {
        var product = productDto.MapToProduct();
        var updatedProduct = await repository.Update(product);
        return updatedProduct.MapToDTO();
    }
}
