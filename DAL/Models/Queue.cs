using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Queue
{
    public int Id { get; set; }

    public string IdPatient { get; set; } = null!;

    public string IdDoctor { get; set; } = null!;

    public DateTime Date { get; set; }

    public int StartHour { get; set; }

    public int StartMinute { get; set; }

    public int EndHour { get; set; }

    public int EndMinute { get; set; }

    public int IdClinic { get; set; }

    public string? Description { get; set; }

    public int IsReminded { get; set; }

    public virtual Clinic IdClinicNavigation { get; set; } = null!;

    public virtual Doctor IdDoctorNavigation { get; set; } = null!;

    public virtual Patient IdPatientNavigation { get; set; } = null!;
}
