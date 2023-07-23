using System.ComponentModel.DataAnnotations;

namespace Model.DbEntities
{
    public class Clinic
    {
        public int ClinicId { get; set; }

        [Required(ErrorMessage = "The clinic name is required.")]
        public string Name { get; set; }

        public IList<Booking> Bookings { get; set; } = null!;
    }

}