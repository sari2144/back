using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLQueue
    {
        Object GetAll();
        void Add(BLQueue q);
        void Update(BLQueue q);
        bool DetermineNewQueue(BLQueue q);
        void Remove(BLQueue q);
        void CancelQueue(BLQueue q , bool backToAvialable);
    }
}
