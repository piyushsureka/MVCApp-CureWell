using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CureWellMVCApp.Models
{
    public class DoctorSpecialization
    {
        //To do implement necessary logic
        public int DoctorId { get; set; }
        [StringLength(int.MaxValue,MinimumLength=3)]
        public string SpecializationCode { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime SpecializationDate { get; set; }
    }
}
