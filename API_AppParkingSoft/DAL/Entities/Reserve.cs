using System.ComponentModel.DataAnnotations;

namespace API_AppParkingSoft.DAL.Entities
{
    public class Reserve : AuditBase
    {
        [Required(ErrorMessage = "¡El campo {0} es obligatorio!")]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public double TotalCost { get; set; }

        public bool stateVehicle { get; set; }

        //Vehicle
        [Display(Name = "Vehiculos")]
        public Vehicle vehicle { get; set; }


        //System user
        [Display(Name = "Usuario sistema")]
        public User user { get; set; }

    }
}
