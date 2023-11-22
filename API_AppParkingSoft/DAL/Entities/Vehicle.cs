using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace API_AppParkingSoft.DAL.Entities
{
    public class Vehicle:AuditBase
    {
        [Required(ErrorMessage = "¡El campo {0} es obligatorio!")]
        public string LicensePlate { get; set; }

        [Required(ErrorMessage = "¡El campo {1} es obligatorio!")]
        public string vehicleOwner { get; set; }
        
        public string? Brand { get; set; }
        public string? Model { get; set; }

        //Vehicle type
        [Display(Name = "VehicleType")]
        public ICollection<CategoryVehicle>? CategoryVehicles { get; set; }

        //Id Client

        [Display(Name = "idClient")]
        public ICollection<Client>? Clients { get; set; }
    }
}
