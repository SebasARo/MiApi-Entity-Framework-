
using MiApi.Models;

namespace MiApi.Services
{
    public interface IProductService
    {
        List<Producto> GetProducts();
        Producto? GetProduct(int id);
        Producto? CreateProduct(Producto product);
        bool UpdateProduct(int id, Producto updatedProduct);
        bool DeleteProduct(int id);
    }
}
