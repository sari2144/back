using DAL.Api;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class DalDoctorService : IDalDoctor
    {
        dbcontext data;
        public DalDoctorService(dbcontext data)
        {
            this.data = data;
        }
        public void Add(Doctor doctor)
        {
            if (doctor == null)
                return;
            if (!data.Doctors.Contains(doctor)) { 
                data.Doctors.Add(doctor);
                data.SaveChanges();
            }
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetAll()
        {
            return data.Doctors.ToList();
        }

        public Doctor GetById(string id)
        {
            return GetAll().Find(d => d.Id.Equals(id));
        }

        public void Update(Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}
