using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Api
{
    public interface IDalReadWriteDataFromFiles
    {
        DateTime GetLastDateThatAvialableQWasUpdated();
        void SetLastDateThatAvialableQWasUpdated(DateTime date);
        DateTime GetLastDateFromDetermindQ();
        void SetLastDateFromDetermindQ(DateTime date);
    }
}
