
using MiApi.Models;

namespace MiApi.Services
{
    public interface IUserService
    {
        List<User> GetUsers();
        User? GetUser(int id);
        User? CreateUser(User user);
        bool UpdateUser(int id, User updatedUser);
        bool DeleteUser(int id);

        List<Producto> GetProductsByUser(int userId);
    }
}

