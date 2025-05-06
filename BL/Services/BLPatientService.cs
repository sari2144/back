using BL.Api;
using BL.Models;
using DAL.Api;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BLPatientService : IBLPatient
    {
        IDalPatient data;
        public BLPatientService(IDal dalMan)
        {
            data = dalMan.Patients;
        }

        public bool Add(BLPatient patient)
        {
            if (patient != null) {
                return data.Add(ConvertToDal(patient));
            }
            return false;
        }

        public void DeleteById(string id)
        {
            
        }

        public List<BLPatient> GetAll()
        {
            List<Patient> patients = data.GetAll();
            List<BLPatient> res = new List<BLPatient>();    
            patients.ForEach(patient => { res.Add(ConvertToBL(patient)); });
            return res;
        }

        public BLPatient GetById(string id)
        {
            try
            {
                Patient patient = data.GetById(id);
                if(patient != null) 
                {
                    return ConvertToBL(patient);
                }
            }
            catch (Exception)
            {

                throw new Exception("not found");
            }
            return null;
            
        }

        public void Update(BLPatient patient)
        {
            throw new NotImplementedException();
        }

        private BLPatient ConvertToBL(Patient p) => new BLPatient() { Id = p.Id , BirthDate = p.BirthDate , City = p.City , FirstName = p.FirstName , LastName = p.LastName , Gender = p.Gender , Phone = p.Phone , Street = p.Street , StreetNumber = p.StreetNumber };
        private Patient ConvertToDal(BLPatient p) => new Patient() { Id = p.Id, BirthDate = p.BirthDate, City = p.City, FirstName = p.FirstName, LastName = p.LastName, Gender = p.Gender, Phone = p.Phone, Street = p.Street, StreetNumber = p.StreetNumber }; 
    };
}

