using DAL.Api;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class DalPatientService : IDalPatient
    { 
        dbcontext data;
        public DalPatientService(dbcontext data)
        {
            this.data = data;
        }

        public bool Add(Patient patient)
        {
            if (patient == null)
                return false;
            if (!data.Patients.Contains(patient))
            {
                data.Patients.Add(patient);
                data.SaveChanges();
                return true;
            }
            return false;
        }

        public void DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Patient> GetAll()
        {
            return data.Patients.ToList();
        }

        public Patient GetById(string id)
        {
            return GetAll().Find(p => p.Id.Equals(id));
        }

        public void Update(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
