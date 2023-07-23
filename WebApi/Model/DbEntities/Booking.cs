using Model.Consts;
using System.ComponentModel.DataAnnotations;

namespace Model.DbEntities
{

    public class Booking
    {
        public int BookingId { get; set; }
        public int ClinicId { get; set; }
        [Required(ErrorMessage = "The booking date is required.")]
        public DateTime Date { get; set; }
        [StringLength(100, MinimumLength = 2)]
        public string FullName { get; set; } = null!;
        [Range(typeof(DateTime), "1/1/1823", "{0}")]
        public DateTime dateOfBirth { get; set; }
        public Gender Gender { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string phoneNumber { get; set; } = null!;

        [RegularExpression(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b")]
        public string IPAddress { get; set; } = null!;
        public Clinic Clinic { get; set; } = null!;
    }
}