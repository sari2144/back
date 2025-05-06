using System;
using System.Collections.Generic;

namespace BL.Models;

public partial class BLWorkingTime
{
    public int Id { get; set; }

    public string DayWeek { get; set; } = null!;

    public string IdDoctor { get; set; } = null!;

    public int StartHour { get; set; }

    public int StartMinute { get; set; }

    public int EndHour { get; set; }

    public int EndMinute { get; set; }

    public int IdClinic { get; set; }

    
}
