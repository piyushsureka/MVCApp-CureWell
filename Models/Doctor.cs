using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CureWellMVCApp.Models
{
    public class Doctor
    {
        //To do implement necessary logic
        public int DoctorId { get; set; }
        [Required]
        public string DoctorName { get; set; }
    }
}
