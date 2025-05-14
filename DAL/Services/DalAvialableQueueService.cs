using DAL.Api;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class DalAvialableQueueService : IDalAvialableQueue
    {
        dbcontext data;

        public DalAvialableQueueService()
        {
        }

        public DalAvialableQueueService(dbcontext data)
        {
            this.data = data;
        }

        public void Add(AvailableQueue newAQueue)
        {
           data.Add(newAQueue);
           data.SaveChanges();
        }

        public List<AvailableQueue> GetAll()
        {
            return data.AvailableQueues.ToList();
        }

        public void Remove(AvailableQueue AQueue)
        {
            var r = data.AvailableQueues.ToList().Find(x => x.Id  == AQueue.Id);
            data.AvailableQueues.Remove(r);
            data.SaveChanges();
        }
    }
}
