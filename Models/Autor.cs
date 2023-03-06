using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Autor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
