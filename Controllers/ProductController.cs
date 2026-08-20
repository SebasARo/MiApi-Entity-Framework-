using Microsoft.AspNetCore.Mvc;
using MiApi.Services;
using MiApi.Models;

namespace MiApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
           {
              _productService = productService;
           }

[HttpGet]
    public ActionResult<IEnumerable<Producto>> GetProducts()
    {
        return Ok(_productService.GetProducts());
    }


[HttpGet("{id}")]
    public ActionResult<Producto> GetProduct(int id)
    {
        if (id <= 0)
        {
            return BadRequest("El ID debe ser mayor a 0.");
        }

        var product = _productService.GetProduct(id);

        if (product == null)
        {
            return NotFound($"No existe un producto con el ID {id}.");
        }

        return Ok(product);
    }

[HttpPost]
public ActionResult<Producto> CreateProduct([FromBody] Producto product)
{
    try
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

       var createdProduct = _productService.CreateProduct(product);

     if (createdProduct == null)
       {
    return BadRequest("No se pudo crear el producto. Verifica los datos enviados.");
       }

        return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.Id }, createdProduct);

    }
    catch (Exception)
    {
        return StatusCode(500, "Ocurrió un error inesperado.");
    }
}

  [HttpPut("{id}")]
public IActionResult UpdateProduct(int id, Producto updatedProduct)
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

        var update = _productService.UpdateProduct(id, updatedProduct);

        if (!update)
        {
            return NotFound();
        }

        return Ok(updatedProduct);
    }
    catch (Exception)
    {
        return StatusCode(500, "Ocurrió un error inesperado.");
    }
}


 [HttpDelete("{id}")]
         public IActionResult DeleteProduct(int id)
    {
         if (id <= 0)
         {
         return BadRequest("El ID debe ser mayor a 0.");
         }
        var delete = _productService.DeleteProduct(id);

        if (!delete)
        {
            return NotFound($"No existe un producto con el ID {id}.");
        }

        return Ok($"El Producto con ID: {id} ha sido eliminado.");
    }

    }
}