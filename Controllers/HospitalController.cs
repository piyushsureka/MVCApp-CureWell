using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CureWellDataAccessLayer;
using CureWellDataAccessLayer.Models;
//using CureWellDataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CureWellMVCApp.Controllers
{
    public class HospitalController : Controller
    {
        #region Uncomment the below lines
        private readonly CureWellContext _context;
        private readonly IMapper _mapper;
        CureWellRepository repObj;
        #endregion

        #region Constructor - Do not modify the signature
        //Uncomment the following method after scaffolding Models
        public HospitalController(CureWellContext context, IMapper mapper)
        {
            //To Do: Implement appropriate logic 
            _context = context;
            _mapper = mapper;
            repObj = new CureWellRepository(_context);
            
        }
        #endregion

        #region GetAllDoctors-Do not modify the signature of the Action
        public ActionResult GetAllDoctors()
        {
            try
            {
                List<Models.Doctor> lst = new List<Models.Doctor>();
                var list = repObj.GetAllDoctors();
                foreach (var item in list)
                {
                    lst.Add(_mapper.Map<Models.Doctor>(item));
                }
                return View(lst);
            }
            catch (Exception)
            {

                return View("Error");
            }
            //To Do: Implement appropriate logic and change the return statement as per your logic
            
        }
        #endregion

        #region Details-Do not modify the signature of the Action
        // GET
        public ActionResult Details(Models.Doctor doctor)
        {
            try
            {
                var obj = repObj.GetDoctor(doctor.DoctorId);
                return View(_mapper.Map<Models.Doctor>(obj));
            }
            catch (Exception)
            {
                return View("Error");

            }
          
        }
        #endregion

        #region Edit-Do not modify the signature of the Action
        // GET
        public ActionResult Edit(Models.Doctor doctor)
        {
            return View(doctor);
        }

        // POST     
        public ActionResult UpdateDoctorDetails(Models.Doctor doctor)
        {
            try
            {
                bool status = repObj.UpdateDoctorDetails(_mapper.Map<Doctor>(doctor));
                if (status)
                {
                    return View("Success");
                }
                else
                    return View("Edit",doctor);
            }
            catch (Exception)
            {

                return View("Error");
            }

        }
        #endregion

        #region Delete-Do not modify the signature of the Action
        // GET
        public ActionResult Delete(Models.Doctor doctor)
        {
            return View(doctor);
        }

        // POST
        public ActionResult DeleteDoctorDetails(int doctorId)
        {
            try
            {
                bool status = repObj.DeleteDoctorDetails(doctorId);
                if (status)
                    return View("Success");
                else
                    return View("Error");
            }
            catch (Exception)
            {

                return View("Error");
            }
            
        }
        #endregion
    }
}