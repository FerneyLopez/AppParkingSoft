using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace API_AppParkingSoft.DAL.Entities
{
    public class Vehicle:AuditBase
    {
        [Display(Name = "Vehicle")]
        [MaxLength(10, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "¡El campo {0} es obligatorio!")]
        public string Name { get; set; }


        [Display (Name = "Users")]

        public
    }
}
