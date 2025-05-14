using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBLReadWriteDataFromFiles
    {
        DateTime GetLastDateThatAvialableQWasUpdated();
        void SetLastDateThatAvialableQWasUpdated(DateTime date);
        DateTime GetLastDateFromDetermindQ();
        void SetLastDateFromDetermindQ(DateTime date);
    }
}
