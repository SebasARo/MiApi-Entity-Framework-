using Microsoft.AspNetCore.Mvc;
using MiApi.Services;
using MiApi.Models;

namespace MiApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
           {
              _userService = userService;
           }
//---------------------------- Obtener todos los Usuarios --------------------------------------------------------------------------
     [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        var users = _userService.GetUsers();
            return Ok(users);
    }
//---------------------------- Obtener los productos de un usuario --------------------------------------------------------------------------
  [HttpGet("{id}/products")]
public ActionResult<IEnumerable<Producto>> GetUserProducts(int id)
{
    if (id <= 0)
        return BadRequest("El ID debe ser mayor a 0.");

    var user = _userService.GetUser(id);

    if (user == null)
        return NotFound($"No existe un usuario con el ID {id}.");

    var products = _userService.GetProductsByUser(id);

    return Ok(products);
}
//---------------------------- Mostrar solo el usuario por id --------------------------------------------------------------------------

    [HttpGet("{id}")]
    public ActionResult<User> GetUser(int id)
    {
       if (id <= 0)
                return BadRequest("El ID debe ser mayor a 0.");

            var user = _userService.GetUser(id);

            if (user == null)
                return NotFound($"No existe un usuario con el ID {id}.");

            return Ok(user);
    }

//---------------------------- Crear un nuevo usuario --------------------------------------------------------------------------
        [HttpPost]
public ActionResult<User> CreateUser(User user)
{
    try
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

       var createdUser = _userService.CreateUser(user);
       if (createdUser == null)
        {
            return Conflict($"Ya existe un usuario con el Id {user.Id}.");
        }

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }
    catch (Exception)
    {
        return StatusCode(500, "Ocurrió un error inesperado.");
    }
}

//---------------------------- Actualizar un usuario existente por su ID --------------------------------------------------------------------------

        [HttpPut("{id}")]
public IActionResult UpdateUser(int id, User updatedUser)
{
    try
    {
         if (id <= 0)
                {
                 return BadRequest("El ID debe ser mayor a 0.");
                }
       
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var update = _userService.UpdateUser(id, updatedUser);

        if (!update)
        {
            return NotFound();
        }

        return Ok(updatedUser);
        
    }
    catch (Exception)
    {
        return StatusCode(500, "Ocurrió un error inesperado.");
    }
    
}

//---------------------------- Eliminar un usuario por su ID --------------------------------------------------------------------------

        [HttpDelete("{id}")]
         public IActionResult DeleteUser(int id)
    {
        if (id <= 0)
        {
         return BadRequest("El ID debe ser mayor a 0.");
        }
        var delete = _userService.DeleteUser(id);

        if (!delete)
        {
            return NotFound($"No existe un usuario con el ID {id}.");
        }

        return Ok($"El Usuario con ID: {id} ha sido eliminado.");
    }
    }


}