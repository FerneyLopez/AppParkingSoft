using System.ComponentModel.DataAnnotations;

namespace API_AppParkingSoft.DAL.Entities
{
    public class Reserve : AuditBase
    {
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public double TotalCost { get; set; }

        public bool activeVehicle { get; set; }

        //Vehicle
        [Display(Name = "Vehiculos")]
        public string LicensePlate { get; set; }


        //System user
        [Display(Name = "Usuario sistema")]
        public string NameUser { get; set; }

    }
}
