using DAL.Api;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class DalSpecialityService:IDalSpeciality
    {
        dbcontext data;
        public DalSpecialityService(dbcontext data) 
        {
            this.data = data;
        }

        public List<Speciality> GetAll()
        {
            return data.Specialities.ToList();
        }
    }
}
