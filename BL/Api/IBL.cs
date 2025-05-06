using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBL
    {
        public IBLDoctor Doctors { get;}
        public IBLQueue Queues { get; }
        public IBLSpeciality Specialities { get;}
        public IBLWorkingTime WorkingTimes { get;}
        public IBLPatient Patients { get; }
        public IBLClinic Clinics { get; }

        public IBLAvialableQueue AvialableQueues { get;}
    }
}
