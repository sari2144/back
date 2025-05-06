using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Clinic
{
    public int Id { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public int StreetNumber { get; set; }

    public virtual ICollection<Archive> Archives { get; set; } = new List<Archive>();

    public virtual ICollection<AvailableQueue> AvailableQueues { get; set; } = new List<AvailableQueue>();

    public virtual ICollection<Queue> Queues { get; set; } = new List<Queue>();

    public virtual ICollection<WorkingTime> WorkingTimes { get; set; } = new List<WorkingTime>();
}
