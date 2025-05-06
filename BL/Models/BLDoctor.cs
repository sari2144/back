using System;
using System.Collections.Generic;

namespace BL.Models;

public partial class BLDoctor
{
    public string Id { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Speciality { get; set; }

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public virtual ICollection<BLArchive> Archives { get; set; } = new List<BLArchive>();

    public virtual ICollection<BLQueue> Queues { get; set; } = new List<BLQueue>();

    public virtual BLSpeciality SpecialityNavigation { get; set; } = null!;

    public virtual ICollection<BLWorkingTime> WorkingTimes { get; set; } = new List<BLWorkingTime>();
}
