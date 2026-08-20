
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MiApi.Models
{
    public class Producto
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = "";

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public int Stock { get; set; }

          // Foreign Key
        public int UserId { get; set; }

        // Navegación hacia User
          [JsonIgnore] 
        public User? User { get; set; }
    }
}
