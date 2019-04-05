using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CureWellDataAccessLayer.Models;
//using CureWellDataAccessLayer.Models;

namespace CureWellWebServices
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //To do implement necessary logic
            CreateMap<DoctorSpecialization, Models.DoctorSpecialization>();
            CreateMap<Models.DoctorSpecialization, DoctorSpecialization>();
        }
    }

}
