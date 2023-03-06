using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Autor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DisplayName("Nombre del autor")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DisplayName("Apellido del autor")]
        public string Apellido { get; set; }
    }
}
