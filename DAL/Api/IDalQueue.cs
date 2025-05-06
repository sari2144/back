using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
    public interface IDalQueue
    {
        void Add(Queue q);
        void Remove(Queue q);
        void Update(Queue q);
        Queue GetById(int id);
        List<Queue> GetAll();
        List<Queue> GetQueuesByDate(DateTime d);
        List<Queue> GetQueuesByIdPatient(string pId);
        List<Queue> GetQueuesByIdDoctor(string pId);

        

    }
}
