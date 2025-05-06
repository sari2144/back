using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Doctor
{
    public string Id { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Speciality { get; set; }

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public virtual ICollection<Archive> Archives { get; set; } = new List<Archive>();

    public virtual ICollection<AvailableQueue> AvailableQueues { get; set; } = new List<AvailableQueue>();

    public virtual ICollection<Queue> Queues { get; set; } = new List<Queue>();

    public virtual Speciality SpecialityNavigation { get; set; } = null!;

    public virtual ICollection<WorkingTime> WorkingTimes { get; set; } = new List<WorkingTime>();
}
