using BL.Api;
using BL.Models;
using DAL.Models;
using DAL.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BLQueueService : IBLQueue
    {
        IDalQueue data;
        IBLAvialableQueue aQueues;
        public BLQueueService(IDal dalMan, IBLAvialableQueue aQueues)
        {
            data = dalMan.Queues;
            this.aQueues = aQueues;
        }
        public void Add(BLQueue q)
        {
            if (q != null)
                data.Add(convertQueueToDal(q));
        }

        private Queue convertQueueToDal(BLQueue q)
        {
            return new Queue() { Date = q.Date, StartHour = q.StartHour, StartMinute = q.StartMinute, EndHour = q.EndHour, EndMinute = q.EndMinute, Id = q.Id, IdDoctor = q.IdDoctor, IdPatient = q.IdPatient, IdClinic = q.IdClinic, Description = q.Description, IsReminded = q.IsReminded };
        }

        private BLQueue convertQueueToBL(Queue q)
        {
            return new BLQueue() { Date = q.Date, StartHour = q.StartHour, StartMinute = q.StartMinute, EndHour = q.EndHour, EndMinute = q.EndMinute, Id = q.Id, IdDoctor = q.IdDoctor, IdPatient = q.IdPatient, IdClinic = q.IdClinic, Description = q.Description, IsReminded = q.IsReminded };
        }

        public Object GetAll()
        {
            List<BLQueue> list = data.GetAll().Select(q => convertQueueToBL(q)).ToList();
            return list.Select(q => new {Id = q.Id, Date = q.Date.ToString("MM/dd/yyyy"), StartHour = q.StartHour, StartMinute = q.StartMinute, EndHour = q.EndHour, EndMinute = q.EndMinute, IdDoctor = q.IdDoctor, IdPatient = q.IdPatient, IdClinic = q.IdClinic, Description = q.Description, IsReminded = q.IsReminded });
        }

        private bool IsAvialableQueue(BLQueue qq)
        {
            List<BLAvialableQueue> list = aQueues.GetAll();
            for (int h = qq.StartHour, m = qq.StartMinute; h != qq.EndHour && m != qq.EndMinute;)
            {
                BLAvialableQueue aqaq = list.Find(q => q.Date.Equals(qq.Date) && q.Hour == h && q.Minute == m);
                if (list.Find(q => DateOnly.FromDateTime(q.Date).Equals(DateOnly.FromDateTime(qq.Date)) && q.Hour == h && q.Minute == m) == null)
                    return false;
                if (m < 50)
                    m += 10;
                else
                {
                    m = 0;
                    h++;
                }
            }
            return true;
        }

        public bool DetermineNewQueue(BLQueue q)
        {
            IBL blMan = new BLManager();
            if (q == null)
                return false;
            if (IsAvialableQueue(q) == false)
                return false;
            Add(q);
            blMan.AvialableQueues.RemoveFromAvialableQueuesByRange(q.StartHour, q.StartMinute, q.EndHour, q.EndMinute, q.Date);
            return true;

        }

        public void Remove(BLQueue q)
        {
            data.Remove(convertQueueToDal(q));          
        }

        public void CancelQueue(BLQueue q, bool backToAvialable)
        {
            Remove(q);
            if (backToAvialable)
                aQueues.BackQueueToBeAvialable(q);
        }
        public void Update(BLQueue q)
        {
            data.Update(convertQueueToDal(q));
        }
    }
}
