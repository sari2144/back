using DAL.Api;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class DalClinicServices : IDalClinic
    {
        dbcontext data;

        public DalClinicServices(dbcontext data)
        {
            this.data = data;
        }
        public List<Clinic> GetAll()
        {
            return data.Clinics.ToList();
        }

        public List<Clinic> GetByCity(string city)
        {
           return GetAll().FindAll(c => c.City == city);    
        }

        public Clinic GetById(int id)
        {
            return GetAll().Find(c => c.Id == id);
        }
    }
}
