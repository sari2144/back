using BL;
using BL.Api;
using UI.Controllers;

namespace UI
{
    public class UIManager
    {
        public DoctorController Doctors { get;}
        public UIManager()
        {
            IBL bLManager = new BLManager();
            Doctors = new DoctorController(bLManager);
        }

    }
}
