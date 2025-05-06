using DAL.Api;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class DalWokingTimeService : IDalWorkingTime
    {
        dbcontext data;

        public DalWokingTimeService(dbcontext data)
        {
            this.data = data;   
        }
        public List<WorkingTime> GetAll()
        {
            return data.WorkingTimes.ToList();
        }

        public void Update(WorkingTime workingT)
        {
            WorkingTime wt = data.WorkingTimes.ToList().Find(w => w.Id == workingT.Id);  
            if(wt != null)
            {
                wt.StartHour = workingT.StartHour;
                wt.StartMinute = workingT.StartMinute;
                wt.EndHour = workingT.EndHour;
                wt.EndMinute = workingT.EndMinute;
                wt.DayWeek = workingT.DayWeek;
                wt.IdClinic = workingT.IdClinic;
                wt.IdDoctor = workingT.IdDoctor;
                data.SaveChanges();
            }
        }
    }
}
