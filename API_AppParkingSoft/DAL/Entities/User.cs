using System.ComponentModel.DataAnnotations;

namespace API_AppParkingSoft.DAL.Entities
{
    public class User
    {
        [Display(Name = "UserName")]
        [MaxLength(50, ErrorMessage = "The field {0} must have a maximun of {1} characteres")]
        [Required(ErrorMessage = "¡Field {0} is required!")]
        public string Name { get; set; }


        [Display(Name = "LastName")]
        [MaxLength(50, ErrorMessage = "The field {0} must have a maximun of {1} characteres")]
        [Required(ErrorMessage = "¡Field {0} is required!")]
        public string? LastName { get; set; }



        [Display(Name = "Email")]
        public string? Email { get; set; }



        [Display(Name = "Password")]
        [MaxLength(12, ErrorMessage = "The field {0} must have a maximun of {1} characteres")]
        [Required(ErrorMessage = "¡Field {0} is required!")]
        public string? Password { get; set; }


        [Display(Name = "Status")]
        public bool? Status { get; set; }

    }
}
