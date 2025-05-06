using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
    public interface IDalClinic
    {
        List<Clinic> GetAll();
        List<Clinic> GetByCity(string city);
        Clinic GetById(int id);
    }
}
