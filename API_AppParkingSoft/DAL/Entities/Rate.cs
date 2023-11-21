using System.ComponentModel.DataAnnotations;

namespace API_AppParkingSoft.DAL.Entities
{
    public class Rate
    {
        [Display(Name = "descriptionFee")]
        public string Name { get; set; }


        [Display(Name = "costVehicle")]
        [Required(ErrorMessage = "¡Field {0} is required!")]
        public double costVehicle { get; set; }

        public ICollection<CategoryVehicle>? CategoriesVehicles { get; set; }
    }
}
