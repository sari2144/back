using System;
using System.Collections.Generic;

namespace BL.Models;

public partial class BLPatient
{
    public string Id { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string Phone { get; set; } = null!;

    public string? City { get; set; }

    public string? Street { get; set; }

    public int? StreetNumber { get; set; }

   
}
