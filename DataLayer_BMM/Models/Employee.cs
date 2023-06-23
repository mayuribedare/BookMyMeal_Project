using System;
using System.Collections.Generic;

namespace DL_BMM.Models;

public partial class Employee
{
    public int Eid { get; set; }

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Token { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
