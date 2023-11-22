using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace API_AppParkingSoft.DAL.Entities
{
    public class Vehicle:AuditBase
    {
        [Display(Name = "Placa o serie")]
        [Required(ErrorMessage = "¡El campo {0} es obligatorio!")]
        public string LicensePlate { get; set; }

        [Display(Name = "Marca")]
        public string? Brand { get; set; }

        [Display(Name = "Modelo")]
        public string? Model { get; set; }

        //Vehicle type
        [Display(Name = "Tipo de vehiculo")]
        public ICollection<CategoryVehicle>? CategoryVehicles { get; set; }

        //Id Client

        [Display(Name = "Cliente")]
        public Guid ClientId { get; set; }
    }
}
