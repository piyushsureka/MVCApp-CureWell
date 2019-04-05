using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CureWellDataAccessLayer;
using AutoMapper;
using CureWellDataAccessLayer.Models;
//using CureWellDataAccessLayer.Models;

namespace CureWellWebServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CureWellController : ControllerBase
    {
        #region Uncomment the below line
        private readonly IMapper _mapper;
        private readonly CureWellRepository _repository;
        #endregion

        #region Constructor - Do not modify the signature
        public CureWellController(IMapper mapper, CureWellRepository repository)
        {
            //To Do: Implement appropriate logic
            _mapper = mapper;
            _repository = repository;
        }
        #endregion

        #region GetAllDoctorSpecialization - Do not modify the signature
        public JsonResult GetAllDoctorSpecialization()
        {
            List<Models.DoctorSpecialization> lst = new List<Models.DoctorSpecialization>();
            try
            {
                var list = _repository.GetAllDoctorSpecialization();
                foreach (var item in list)
                {
                    lst.Add(_mapper.Map<Models.DoctorSpecialization>(item));
                }
            }
            catch (Exception)
            {

                lst = null;
            }
            //To Do: Implement appropriate logic and change the return statement as per your logic
            return new JsonResult(lst);
        }
        #endregion

        #region AddDoctorSpecialization- Do not modify the signature
        [HttpPost]
        public bool AddDoctorSpecialization(Models.DoctorSpecialization doctorSpecialization)
        {
            bool status = false;
            try
            {
                status=_repository.AddDoctorSpecialization(_mapper.Map<DoctorSpecialization>(doctorSpecialization));

            }
            catch (Exception)
            {

                status = false;
            }
            //To Do: Implement appropriate logic and change the return statement as per your logic
            return status;
        }
        #endregion
    }
}
