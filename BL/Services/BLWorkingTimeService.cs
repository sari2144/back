using BL.Api;
using BL.Models;
using DAL.Api;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BLWorkingTimeService : IBLWorkingTime
    {
        IDalWorkingTime data;
        IBLReadWriteDataFromFiles readWriteData;
        IBLAvialableQueue avialableQ;
        //public BLWorkingTimeService()
        //{
            
        //}
        public BLWorkingTimeService(IDal dal, IBLReadWriteDataFromFiles readWriteData , Lazy<IBLAvialableQueue> avialableQ)
        {
            data = dal.WorkingTimes;
            this.readWriteData = readWriteData;
            this.avialableQ = avialableQ.Value ;
        }
        public List<BLWorkingTime> GetAll()
        {
           
            List<BLWorkingTime> list = data.GetAll().Select(w => convertWorkingTimeToBL(w)).ToList() ;
            return list;

        }

        public void Update(BLWorkingTime workingTime)
        {
            data.Update(convertWorkingTimeToDal(workingTime));
            DateTime d1 = readWriteData.GetLastDateFromDetermindQ();
            d1.AddDays(1);
            DateTime d2 = readWriteData.GetLastDateThatAvialableQWasUpdated();
            avialableQ.DeleteAllAvialableQueuesByDateRange(d1, d2);
            avialableQ.UpdateAllAvialableQueuesByRange(d1, d2);
        }

        private BLWorkingTime convertWorkingTimeToBL(WorkingTime wt) => new BLWorkingTime() { Id = wt.Id, DayWeek = wt.DayWeek,StartHour = wt.StartHour,StartMinute = wt.StartMinute,EndHour = wt.EndHour,EndMinute = wt.EndMinute,IdClinic = wt.IdClinic, IdDoctor = wt.IdDoctor};
       
        private WorkingTime convertWorkingTimeToDal(BLWorkingTime wt) => new WorkingTime() { Id = wt.Id, DayWeek = wt.DayWeek, StartHour = wt.StartHour, StartMinute = wt.StartMinute, EndHour = wt.EndHour, EndMinute = wt.EndMinute, IdClinic = wt.IdClinic, IdDoctor = wt.IdDoctor };
      

    }
}
