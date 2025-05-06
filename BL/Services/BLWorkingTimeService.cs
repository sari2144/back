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
        public BLWorkingTimeService()
        {
            
        }
        public BLWorkingTimeService(IDal dal)
        {
            this.data = dal.WorkingTimes;
        }
        public List<BLWorkingTime> GetAll()
        {
           
            List<BLWorkingTime> list = data.GetAll().Select(w => convertWorkingTimeToBL(w)).ToList() ;
            return list;

        }

        public void Update(BLWorkingTime workingTime)
        {
            data.Update(convertWorkingTimeToDal(workingTime));
        }

        private BLWorkingTime convertWorkingTimeToBL(WorkingTime wt) => new BLWorkingTime() { Id = wt.Id, DayWeek = wt.DayWeek,StartHour = wt.StartHour,StartMinute = wt.StartMinute,EndHour = wt.EndHour,EndMinute = wt.EndMinute,IdClinic = wt.IdClinic, IdDoctor = wt.IdDoctor};
       
        private WorkingTime convertWorkingTimeToDal(BLWorkingTime wt) => new WorkingTime() { Id = wt.Id, DayWeek = wt.DayWeek, StartHour = wt.StartHour, StartMinute = wt.StartMinute, EndHour = wt.EndHour, EndMinute = wt.EndMinute, IdClinic = wt.IdClinic, IdDoctor = wt.IdDoctor };
      

    }
}
