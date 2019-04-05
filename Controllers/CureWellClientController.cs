using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CureWellMVCApp.Repository;
using System.Net.Http;

namespace CureWellMVCApp.Controllers
{
    public class CureWellClientController : Controller
    {
        #region Uncomment the below line
        IConfiguration Configuration;
        #endregion

        #region Constructor - Do not modify the signature
        public CureWellClientController(IConfiguration configuration)
        {
            //To Do: Implement appropriate logic
            Configuration = configuration;
        }
        #endregion

        #region GetAllDoctorSpecialization-Do not modify the signature of the Action
        public ActionResult GetAllDoctorSpecialization()
        {
            try
            {
                ServiceRepository service = new ServiceRepository(Configuration);
                HttpResponseMessage response=service.GetResponse("api/CureWell/GetAllDoctorSpecialization");
                response.EnsureSuccessStatusCode();
                List<Models.DoctorSpecialization> list=response.Content.ReadAsAsync<List<Models.DoctorSpecialization>>().Result;
                return View(list);

            }
            catch (Exception)
            {

                return View("Error");
            }
           

            //To Do: Implement appropriate logic and change the return statement as per your logic
            
        }
        #endregion

        #region Create-Do not modify the signature of the Action
        public ActionResult Create()
        {
            //To Do: Implement appropriate logic and change the return statement as per your logic
            return View();
        }

        public ActionResult AddDoctorSpecialization(Models.DoctorSpecialization doctorSpecialization)
        {
            try
            {
                ServiceRepository service = new ServiceRepository(Configuration);
                HttpResponseMessage response=service.PostRequest("api/CureWell/AddDoctorSpecialization",doctorSpecialization);
                response.EnsureSuccessStatusCode();
                bool status = response.Content.ReadAsAsync<bool>().Result;
                if (status)
                    return View("Success");
                else
                    return View("Error");

            }
            catch (Exception)
            {

                return View();
            }
            //To Do: Implement appropriate logic and change the return statement as per your logic
            
        }
        #endregion
    }
}