using DAL.Models;
using System;
using System.Collections.Generic;

namespace BL.Models;

public partial class BLSpeciality
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
