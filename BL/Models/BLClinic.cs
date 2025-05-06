using System;
using System.Collections.Generic;

namespace BL.Models;

public partial class BLClinic
{
    public int Id { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public int StreetNumber { get; set; }

    public virtual ICollection<BLWorkingTime> WorkingTimes { get; set; } = new List<BLWorkingTime>();
}
