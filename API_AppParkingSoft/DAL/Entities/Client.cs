using System.ComponentModel.DataAnnotations;

namespace API_AppParkingSoft.DAL.Entities
{
    public class Client : AuditBase
    {
        [Display(Name = "clientName")]
        [Required(ErrorMessage = "¡Field {0} is required!")]
        public string clientName { get; set; }

        //Vehicle
        [Display(Name = "Vehicles")]
        public ICollection<Vehicle>? Vehicles { get; set; }
    }
}
