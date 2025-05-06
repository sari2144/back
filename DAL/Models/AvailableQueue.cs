using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class AvailableQueue
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int Hour { get; set; }

    public int Minute { get; set; }

    public string IdDoctor { get; set; } = null!;

    public int IdClinic { get; set; }

    public virtual Clinic IdClinicNavigation { get; set; } = null!;

    public virtual Doctor IdDoctorNavigation { get; set; } = null!;
}
