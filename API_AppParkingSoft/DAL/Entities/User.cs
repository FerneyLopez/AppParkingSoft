using System.ComponentModel.DataAnnotations;

namespace API_AppParkingSoft.DAL.Entities
{
    public class User:AuditBase
    {

        [Display(Name = "Id Usuario")]
        [Required(ErrorMessage = "¡El campo {0} es obligatorio!")]
        public string idUser { get; set; }


        [Display(Name = "Nombre usuario")]
        [MaxLength(50, ErrorMessage = "El campo {1} debe tener por lo menos {1} caracter")]
        [Required(ErrorMessage = "¡El campo {1} es obligatorio!")]
        public string Name { get; set; }


        [Display(Name = "Apellido usuario")]
        [MaxLength(50, ErrorMessage = "El campo {2} debe tener por lo menos {1} caracter")]
        [Required(ErrorMessage = "¡El campo {2} es obligatorio!")]
        public string LastName { get; set; }


        [Display(Name = "Email")]
        public string? Email { get; set; }


        [Display(Name = "Password")]
        [MaxLength(12, ErrorMessage = "El campo {4} debe tener por lo menos {1} caracter")]
        [Required(ErrorMessage = "¡El campo {4} es obligatorio!")]
        public string Password { get; set; }


        [Display(Name = "Estado")]
        public bool? Status { get; set; }

        //Reserves
        [Display(Name = "Reservas")]
        public ICollection<Reserve>? Reserves { get; set; }
    }
}
