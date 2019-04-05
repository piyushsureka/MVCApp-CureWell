using System;
using System.Collections.Generic;

namespace CureWellDataAccessLayer.Models
{
    public partial class DoctorSpecialization
    {
        public int DoctorId { get; set; }
        public string SpecializationCode { get; set; }
        public DateTime SpecializationDate { get; set; }

        public Doctor Doctor { get; set; }
        public Specialization SpecializationCodeNavigation { get; set; }
    }
}
