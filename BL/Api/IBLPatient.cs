using BL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLPatient
    {
        List<BLPatient> GetAll();
        BLPatient GetById(string id);
        void Update(BLPatient patient);
        bool Add(BLPatient patient);
        void DeleteById(string id);

    }
}
