using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class WorkingTime
{
    public int Id { get; set; }

    public string DayWeek { get; set; } = null!;

    public string IdDoctor { get; set; } = null!;

    public int StartHour { get; set; }

    public int StartMinute { get; set; }

    public int EndHour { get; set; }

    public int EndMinute { get; set; }

    public int IdClinic { get; set; }

    public virtual Clinic IdClinicNavigation { get; set; } = null!;

    public virtual Doctor IdDoctorNavigation { get; set; } = null!;
}
