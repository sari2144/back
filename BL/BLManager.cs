using BL.Api;
using BL.Services;
using DAL;
using DAL.Api;
using DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BLManager:IBL
    {
        IDal dalMan { get; set;}
        public IBLDoctor Doctors { get; }
        public IBLQueue Queues { get; }
        public IBLClinic Clinics { get; }
        public IBLPatient Patients { get; }

        public IBLSpeciality Specialities { get; }  
        public IBLWorkingTime WorkingTimes { get; }
        public IBLAvialableQueue AvialableQueues { get; }
        public BLManager()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<IDal, DalManager>();
            services.AddSingleton<IBL, BLManager>();
            services.AddSingleton<IBLDoctor, BLDoctorService>();
            services.AddSingleton<IBLSpeciality,BLSpecialityService>();
            services.AddSingleton<IBLWorkingTime, BLWorkingTimeService>();
            services.AddSingleton<IBLAvialableQueue, BLAvialableQueueService>();
            services.AddSingleton<IBLQueue, BLQueueService>();
            services.AddSingleton<IBLClinic, BLClinicService>();
            services.AddSingleton<IBLPatient, BLPatientService>();
            
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            Doctors = serviceProvider.GetRequiredService<IBLDoctor>();
            Specialities = serviceProvider.GetRequiredService<IBLSpeciality>();
            WorkingTimes = serviceProvider.GetRequiredService<IBLWorkingTime>();
            AvialableQueues = serviceProvider.GetRequiredService<IBLAvialableQueue>();
            Queues = serviceProvider.GetRequiredService<IBLQueue>();
            Clinics = serviceProvider.GetRequiredService<IBLClinic>();
            Patients = serviceProvider.GetRequiredService<IBLPatient>();
            



        }
    }
}
