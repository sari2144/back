using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Archive
{
    public int Id { get; set; }

    public string IdPatient { get; set; } = null!;

    public string IdDoctor { get; set; } = null!;

    public DateTime Date { get; set; }

    public int Hour { get; set; }

    public int Minute { get; set; }

    public string IsPayed { get; set; } = null!;

    public int IdClinic { get; set; }

    public virtual Clinic IdClinicNavigation { get; set; } = null!;

    public virtual Doctor IdDoctorNavigation { get; set; } = null!;

    public virtual Patient IdPatientNavigation { get; set; } = null!;
}
