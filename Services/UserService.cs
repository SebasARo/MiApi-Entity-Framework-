
using MiApi.Models;
using MiApi.Data;
using Microsoft.EntityFrameworkCore;


namespace MiApi.Services
{
public class UserService : IUserService
{
     private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }


    public List<User> GetUsers()
    {
        return _context.Users
                .Include(u => u.Productos)
                .ToList();
    }

    public User? GetUser(int id)
    {
        return _context.Users
                .Include(u => u.Productos)
                .FirstOrDefault(u => u.Id == id);
    }

    public User? CreateUser(User user)
    {
        // Verificar si ya existe un usuario con el mismo Id
    if (_context.Users.Any(u => u.Id == user.Id))
    {
        return null;
    }

    _context.Users.Add(user);
    _context.SaveChanges();
    return user;
    }

    public bool UpdateUser(int id, User updatedUser)
    {
        var user = _context.Users.Find(id);

        if (user == null)
            return false;

        user.Nombre = updatedUser.Nombre;
        user.Edad = updatedUser.Edad;
        user.Email = updatedUser.Email;

        _context.SaveChanges();
        return true;
    }

    public bool DeleteUser(int id)
    {
      var user = _context.Users
                .Include(u => u.Productos)
                .FirstOrDefault(u => u.Id == id);

        if (user == null)
            return false;

        _context.Productos.RemoveRange(user.Productos);
        _context.Users.Remove(user);
        _context.SaveChanges();

        return true;
    }


    //Obtener los productos de un Usuario
    public List<Producto> GetProductsByUser(int userId)
{
    return _context.Productos
        .Where(p => p.UserId == userId)
        .ToList();
}
}
}
