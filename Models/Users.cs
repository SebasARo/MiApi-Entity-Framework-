using System.ComponentModel.DataAnnotations;

namespace MiApi.Models
{
    public class User
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }= "";

        [Required]
        [StringLength(100)]
        public string Email { get; set; } = "";

         [Required]
        public int Edad { get; set; } 

       public List<Producto> Productos { get; set; } = new();

    }
}
