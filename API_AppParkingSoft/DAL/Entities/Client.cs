using System.ComponentModel.DataAnnotations;

namespace API_AppParkingSoft.DAL.Entities
{
    public class Client:AuditBase
    {
        [Display(Name = "Nombre cliente")]
        [Required(ErrorMessage = "¡Field {0} is required!")]
        public string clientName { get; set; }

        [Required(ErrorMessage = "¡Field {1} is required!")]
        public string idClient {  get; set; }

        //Vehicle
        [Display(Name = "Vehiculos")]
        public ICollection<Vehicle>? Vehicles { get; set; }
    }
}
