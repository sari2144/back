using BL.Api;
using DAL.Api;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BLReadWriteDataFromFilesService : IBLReadWriteDataFromFiles
    {
        IDalReadWriteDataFromFiles data;
        public BLReadWriteDataFromFilesService(IDal dalMan)
        {
            data = dalMan.ReadWriteData;
        }
        public DateTime GetLastDateFromDetermindQ()
        {
            return data.GetLastDateFromDetermindQ();
        }

        public DateTime GetLastDateThatAvialableQWasUpdated()
        {
            return data.GetLastDateThatAvialableQWasUpdated();
        }

        public void SetLastDateFromDetermindQ(DateTime date)
        {
            data.SetLastDateFromDetermindQ(date);
        }

        public void SetLastDateThatAvialableQWasUpdated(DateTime date)
        {
            data.SetLastDateThatAvialableQWasUpdated(date);
        }
    }
}
