using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
    public interface IDalPatient
    {
        List<Patient> GetAll();
        Patient GetById(string id);
        void Update(Patient patient);
        bool Add(Patient patient);
        void DeleteById(string id);

    }
}
