using Model.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos
{
    public class BookingForAddDto
    {
        public int ClinicId { get; set; }
        [StringLength(100, MinimumLength = 2)]
        public string FullName { get; set; } = null!;
        public DateTime dateOfBirth { get; set; }
        public Gender Gender { get; set; }
        [StringLength(100, MinimumLength = 2)]
        public string phoneNumber { get; set; } = null!;
      

    }
}
