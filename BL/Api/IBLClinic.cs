using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLClinic
    {
        List<BLClinic> GetAll();
        List<BLClinic> GetByCity(string city);
        BLClinic GetById(int id);
    }
}
