using BL.Api;
using BL.Models;
using DAL;
using DAL.Api;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BLDoctorService:IBLDoctor
    {
        IDalDoctor data;
        public BLDoctorService(IDal dal) 
        {
            data = dal.Doctors;
        }

        public void Add(BLDoctor doctor)
        {
            throw new NotImplementedException();
        }

        public List<BLDoctor> GetAll()
        {
            List<BLDoctor> list;
            list = data.GetAll().Select(d => convertDoctorToBL(d)).ToList();
            return list;
        }

        public BLDoctor GetById(string id)
        {
            return convertDoctorToBL(data.GetById(id));
        }

        public List<BLDoctor> GetBySubName(string subName)
        {
            return GetAll().FindAll(d => d.FirstName.ToLower().Contains(subName.ToLower()) || d.LastName.ToLower().Contains(subName.ToLower()));
        }

        private BLDoctor convertDoctorToBL(Doctor doctor)
        {
            return new BLDoctor() {Id = doctor.Id , FirstName = doctor.FirstName , LastName = doctor.LastName , Email = doctor.Email , Phone = doctor.Phone ,Speciality = doctor.Speciality };
        }
    }
}
