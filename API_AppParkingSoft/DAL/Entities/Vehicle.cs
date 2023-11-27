using System.ComponentModel;
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
        public CategoryVehicle? CategoryVehicle { get; set; }
        public string CategoryName { get; set; }
        //Reserves
        [Display(Name = "Reserves")]
        public ICollection<Reserve>? Reserves { get; set; }

    }
}
