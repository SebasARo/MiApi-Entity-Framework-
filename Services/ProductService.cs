using MiApi.Data;
using MiApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MiApi.Services
{
public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public List<Producto> GetProducts()
    {
        return _context.Productos
                .Include(p => p.User)
                .ToList();
    }

    public Producto? GetProduct(int id)
    {
         return _context.Productos
                .Include(p => p.User)
                .FirstOrDefault(p => p.Id == id);
    }

    public Producto? CreateProduct(Producto product)
    {
         var userExists = _context.Users.Any(u => u.Id == product.UserId);
            if (!userExists)
                return null;

        _context.Productos.Add(product);
        _context.SaveChanges();
        return product;
    }

    public bool UpdateProduct(int id, Producto updatedProduct)
    {
        var product = _context.Productos.Find(id);
        if (product == null) 
        return false;

        product.Nombre = updatedProduct.Nombre;
        product.Precio = updatedProduct.Precio;
        product.Stock = updatedProduct.Stock;


        // Si cambia el usuario asignado
          if (product.UserId != updatedProduct.UserId)
            {
                var userExists = _context.Users.Any(u => u.Id == updatedProduct.UserId);
                if (!userExists)
                    return false;

                product.UserId = updatedProduct.UserId;
            }

            _context.SaveChanges();
            return true;
    }

    public bool DeleteProduct(int id)
    {
        var product = _context.Productos.Find(id);
        if (product == null) 
        return false;

        _context.Productos.Remove(product);
        _context.SaveChanges();
        return true;
    }
}
}