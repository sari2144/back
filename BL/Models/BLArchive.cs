using System;
using System.Collections.Generic;

namespace BL.Models;

public partial class BLArchive
{
    public int Id { get; set; }

    public string IdPatient { get; set; } = null!;

    public string IdDoctor { get; set; } = null!;

    public DateTime Date { get; set; }

    public int Hour { get; set; }

    public int Minute { get; set; }

    public int IdClinic { get; set; }
    public string IsPayed { get; set; } = null!;

    public virtual BLDoctor IdDoctorNavigation { get; set; } = null!;

    public virtual BLPatient IdPatientNavigation { get; set; } = null!;
}
