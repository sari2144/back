using DAL.Api;
using DAL.Models;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DalManager:IDal
    {
        public IDalDoctor Doctors { get; }
        public IDalPatient Patients { get; }
        public IDalQueue Queues { get; }
        public IDalClinic Clinics { get; }
        public IDalSpeciality Specialities { get; }
        public IDalWorkingTime WorkingTimes { get; }
        public IDalAvialableQueue AvagingQueues { get; }

 

        public DalManager()
        {
            dbcontext data = new dbcontext();

            Patients = new DalPatientService(data); 
            Doctors = new DalDoctorService(data);
            Specialities = new DalSpecialityService(data);
            WorkingTimes = new DalWokingTimeService(data);
            AvagingQueues = new DalAvialableQueueService(data);
            Queues = new DalQueueService(data);
            Clinics = new DalClinicServices(data);
        }


    }
}
