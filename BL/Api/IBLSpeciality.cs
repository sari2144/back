﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;

namespace BL.Api
{
    public interface IBLSpeciality
    {
        List<BLSpeciality> GetAll();
    }
}
