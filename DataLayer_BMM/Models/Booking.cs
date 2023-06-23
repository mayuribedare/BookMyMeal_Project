using System;
using System.Collections.Generic;

namespace DL_BMM.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int Eid { get; set; }

    public DateTime? Date { get; set; }

    public virtual Employee EidNavigation { get; set; } = null!;
}
