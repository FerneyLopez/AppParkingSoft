using System.ComponentModel.DataAnnotations;

namespace API_AppParkingSoft.DAL.Entities
{
    public class Reserve : AuditBase
    {
        [Required(ErrorMessage = "¡El campo {0} es obligatorio!")]
        public DateTime StartDate { get; set; }

        public DateTime ? FinalDate { get; set; }

        public double TotalCost { get; set; }

        //Vehicle type
        [Display(Name = "Vehicle")]
        public ICollection<Vehicle> vehicles { get; set; }

        //System user
        [Display(Name = "System user")]
        public ICollection<User> users { get; set; }
    }
}
