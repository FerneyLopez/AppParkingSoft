using System.ComponentModel.DataAnnotations;

namespace API_AppParkingSoft.DAL.Entities
{
    public class Client : AuditBase
    {
        [Display(Name = "idClient")]
        [MaxLength(12, ErrorMessage = "The field {1} must have a maximun of {1} characteres")]
        [Required(ErrorMessage = "¡Field {1} is required!")]
        public string idClient { get; set; }


        [Display(Name = "clientName")]
        [Required(ErrorMessage = "¡Field {0} is required!")]
        public string clientName { get; set; }

    }
}
