using System.ComponentModel.DataAnnotations;

namespace API_AppParkingSoft.DAL.Entities
{
    public class Rate : AuditBase
    {
        [Display(Name = "descriptionFee")]
        [Required(ErrorMessage = "¡Field {0} is required!")]
        public string Name { get; set; }


        [Display(Name = "hourly parking rate")]
        [Required(ErrorMessage = "¡Field {1} is required!")]
        public double hourlyRate { get; set; }

        [Display(Name = "weekly parking rate")]
        [Required(ErrorMessage = "¡Field {2} is required!")]
        public double weeklyRate { get; set; }

        [Display(Name = "monthly parking rate")]
        [Required(ErrorMessage = "¡Field {3} is required!")]
        public double monthlyRate { get; set; }

        public ICollection<CategoryVehicle>? CategoriesVehicles { get; set; }
    }
}
