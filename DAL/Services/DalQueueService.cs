using DAL.Api;
using DAL.Models;

namespace DAL.Services
{
    public class DalQueueService : IDalQueue
    {
        dbcontext data;
        public DalQueueService(dbcontext data)
        {
            this.data = data;
        }

        public void Add(Queue q)
        {
            if(q != null) 
                data.Add(q);
            data.SaveChanges();
          
        }

        public List<Queue> GetAll()
        {
            return data.Queues.ToList();
        }

        public Queue GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Queue> GetQueuesByDate(DateTime d)
        {
            throw new NotImplementedException();
        }

        public List<Queue> GetQueuesByIdDoctor(string pId)
        {
            throw new NotImplementedException();
        }

        public List<Queue> GetQueuesByIdPatient(string pId)
        {
            throw new NotImplementedException();
        }

        public void Remove(Queue q)
        {
            //if (data.Queues.Contains(q))
            //{
            //    data.Queues.Remove(q);
            //    data.SaveChanges();
            //}
            var r = data.Queues.ToList().Find(x => x.Id == q.Id);
            data.Queues.Remove(r);
            data.SaveChanges();
        
        }

        public void Update(Queue q)
        {
            Queue queue = data.Queues.ToList().Find(q => q.Id == q.Id);

            if(queue != null) {
                queue.IdDoctor = q.IdDoctor;
                queue.IdClinic = q.IdClinic;
                queue.EndHour = q.EndHour;
                queue.EndMinute = q.EndMinute;
                queue.StartHour = q.StartHour;
                queue.StartMinute = q.StartMinute;
                queue.Date = q.Date;
                queue.Description = q.Description;
                queue.IsReminded = q.IsReminded;
                data.SaveChanges();
            }
                   
        }
    }
}