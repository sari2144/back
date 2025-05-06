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
    internal class BLClinicService : IBLClinic
    {
        IDalClinic data;

        public BLClinicService(IDal dalMan)
        {
            data = dalMan.Clinics;
        }
        public List<BLClinic> GetAll()
        {
            List<Clinic> list = data.GetAll();
            List<BLClinic> result = new List<BLClinic>();
            foreach (var item in list)
            {
                result.Add(convertToBL(item));
            }
            return result;
        }

        public List<BLClinic> GetByCity(string city)
        {
            return GetAll().FindAll(c => c.City == city);
        }

        public BLClinic GetById(int id)
        {
            return convertToBL(data.GetById(id));
        }

        private BLClinic convertToBL(Clinic c) => new BLClinic() {Id = c.Id , City = c.City , Street = c.Street , StreetNumber = c.StreetNumber };
       
        private Clinic convertToDal(BLClinic c) => new Clinic() {  Id = c.Id , City = c.City , Street = c.Street ,StreetNumber = c.StreetNumber };
    }
}
