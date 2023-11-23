using System.ComponentModel.DataAnnotations;

namespace API_AppParkingSoft.DAL.Entities
{
    public class CategoryVehicle:AuditBase
    {
        [Required(ErrorMessage = "¡El campo {0} es obligatorio!")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "¡El campo {1} es obligatorio!")]
        public int typeCategory { get; set; }

        //Rates
        [Display(Name = "Tarifas")]
        public ICollection<Rate>? Rates { get; set; }
    }
}
