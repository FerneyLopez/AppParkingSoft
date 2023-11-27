using System.ComponentModel.DataAnnotations;

namespace API_AppParkingSoft.DAL.Entities
{
    public class CategoryVehicle:AuditBase
    {
        [Required(ErrorMessage = "¡El campo {0} es obligatorio!")]
        public string CategoryName { get; set; }

        //Rates
        [Display(Name = "Tarifa")]
        public Rate? Rate { get; set; }
        public Guid? IdRate { get; set; }

    }
}
