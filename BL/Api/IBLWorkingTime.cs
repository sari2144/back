using BL.Models;
using DAL.Models;

namespace BL.Api
{
    public interface IBLWorkingTime
    {
        List<BLWorkingTime> GetAll();
        void Update(BLWorkingTime workingTime);
    }
}