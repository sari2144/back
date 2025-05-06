using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
    public interface IDalAvialableQueue
    {
        public List<AvailableQueue> GetAll();
        public void Add(AvailableQueue newAQueue);
        public void Remove(AvailableQueue AQueue);
    }
}
