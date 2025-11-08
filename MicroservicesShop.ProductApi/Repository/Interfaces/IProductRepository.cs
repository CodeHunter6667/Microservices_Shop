using MicroservicesShop.ProductApi.Models;

namespace MicroservicesShop.ProductApi.Repository.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAll();
    Task<Product> GetById(int id);
    Task<Product> Create(Product product);
    Task<Product> Update(Product product);
    Task<bool> Delete(int id);
}
