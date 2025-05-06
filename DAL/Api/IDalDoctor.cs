using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
    public interface IDalDoctor
    {
        List<Doctor> GetAll();
        Doctor GetById(string id);
        void DeleteById(string id);
        void Update(Doctor doctor);
        void Add(Doctor doctor);
        
    }
}
