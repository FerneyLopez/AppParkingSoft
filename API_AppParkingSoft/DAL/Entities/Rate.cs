using System.ComponentModel.DataAnnotations;

namespace API_AppParkingSoft.DAL.Entities
{
    public class Rate : AuditBase
    {
        [Display(Name = "Descripcion tarifa")]
        [Required(ErrorMessage = "¡El campo {0} es obligatorio!")]
        public string RateName { get; set; }

        [Display(Name = "Tarifa por hora")]
        [Required(ErrorMessage = "¡El campo {1} es obligatorio!")]
        public double hourlyRate { get; set; }

        [Display(Name = "Tarifa por semana")]
        [Required(ErrorMessage = "¡El campo {2} es obligatorio!")]
        public double weeklyRate { get; set; }

        [Display(Name = "Tarifa mensual")]
        [Required(ErrorMessage = "¡El campo {3} es obligatorio!")]
        public double monthlyRate { get; set; }


        //Vehicle Type
        public CategoryVehicle? CategoryVehicle { get; set; }

        [Display(Name = "Tipo de vehiculo")]
        public Guid idCategoryVehicle { get; set; }
    }
}
