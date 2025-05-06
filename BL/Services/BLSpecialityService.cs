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
    public class BLSpecialityService : IBLSpeciality
    {
        public IDalSpeciality data { get; }

        public BLSpecialityService(IDal dalMan)
        {
            data = dalMan.Specialities;
        }

        public List<BLSpeciality> GetAll()
        {
            List<BLSpeciality> list = data.GetAll().Select(s => convertSpecialityToBL(s)).ToList();
            return list;    
        }

        private BLSpeciality convertSpecialityToBL(Speciality speciality)
        {
            return new BLSpeciality() { Id = speciality.Id, Description = speciality.Description , Doctors = speciality.Doctors};
        }
    }
}
