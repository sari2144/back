using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
    public interface IDal
    {
        public IDalDoctor Doctors { get; }
        public IDalPatient Patients { get; }
        public IDalQueue Queues { get; }
        public IDalClinic Clinics { get; }
        public IDalSpeciality Specialities { get; }
        public IDalWorkingTime WorkingTimes { get; }
        public IDalAvialableQueue AvagingQueues { get; }
        public IDalReadWriteDataFromFiles ReadWriteData { get; }
    }
}
