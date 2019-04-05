//using CureWellDataAccessLayer.Models;
using CureWellDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CureWellDataAccessLayer
{
    public class CureWellRepository
    {
        #region Uncomment the below line
        private readonly CureWellContext _context;
        #endregion

        #region Constructor - Do not modify the signature
        public CureWellRepository()
        {
            //To Do: Implement appropriate logic
            _context = new CureWellContext();
        }
        #endregion

        #region Constructor - Do not modify the signature
        //Uncomment the following after scaffolding models
        public CureWellRepository(CureWellContext context)
        {
            //To Do: Implement appropriate logic
            _context = context;
        }
        #endregion

        #region GetAllDoctors - Do not modify the signature
        //Uncomment the following method after scaffolding models

        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> lst = new List<Doctor>();
            try
            {
                lst = (from d in _context.Doctor select d).ToList();
                return lst;
            }
            catch (Exception)
            {
                return null;

            }
            //To Do: Implement appropriate logic and change the return statement as per your logic
            
        }
        #endregion

        #region GetDoctor - Do not modify the signature
        //Uncomment the following after scaffolding models

        public Doctor GetDoctor(int doctorId)
        {
            Doctor doctor;
            try
            {
                doctor = _context.Doctor.Find(doctorId);
                return doctor;
            }
            catch (Exception)
            {

                return null;
            }
            //To Do: Implement appropriate logic and change the return statement as per your logic
            
        }
        #endregion

        #region GetAllDoctorSpecialization - Do not modify the signature
        //Uncomment the following method after scaffolding models

        public List<DoctorSpecialization> GetAllDoctorSpecialization()
        {
            List<DoctorSpecialization> lst = new List<DoctorSpecialization>();
            try
            {
                lst = (from ds in _context.DoctorSpecialization select ds).ToList();
                return lst;
            }
            catch (Exception)
            {

                return null;
            }
            //To Do: Implement appropriate logic and change the return statement as per your logic
            
        }
        #endregion

        #region AddDoctorSpecialization - Do not modify the signature
        //Uncomment the following method after scaffolding models

        public bool AddDoctorSpecialization(DoctorSpecialization doctorSpecialization)
        {
            bool status = false;
            try
            {
                _context.DoctorSpecialization.Add(doctorSpecialization);
                _context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {

                status = false;
            }
            //To Do: Implement appropriate logic and change the return statement as per your logic
            return status;
        }
        #endregion

        #region UpdateDoctorDetails - Do not modify the signature
        //Uncomment the following method after scaffolding models

        public bool UpdateDoctorDetails(Doctor doct)
        {
            bool status = false;
            try
            {
                var obj = _context.Doctor.Find(doct.DoctorId);
                if (obj != null)
                {
                    obj.DoctorName = doct.DoctorName;
                    _context.SaveChanges();
                    status = true;
                }
                else
                    status = false;

            }
            catch (Exception)
            {

                status = false;
            }
            //To Do: Implement appropriate logic and change the return statement as per your logic
            return status;
        }
        #endregion

        #region DeleteDoctorDetails - Do not modify the signature
        public bool DeleteDoctorDetails(int doctorId)
        {
            bool status = false;
            try
            {
                var obj = _context.Doctor.Find(doctorId);
                _context.Doctor.Remove(obj);
                _context.SaveChanges();
                status = true;
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
