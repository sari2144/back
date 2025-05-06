using BL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLDoctor
    {
        List<BLDoctor> GetAll();
        void Add(BLDoctor doctor);
        List<BLDoctor> GetBySubName(string subName);
        BLDoctor GetById(string id);
    }
}
