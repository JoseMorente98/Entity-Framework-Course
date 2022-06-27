using System.ComponentModel.DataAnnotations;

namespace Proyecto1.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El celular es obligatorio")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "El correo es obligatorio")]
        public string Email { get; set; }
    }
}
