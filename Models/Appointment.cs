using System;
using System.Collections.Generic;

namespace GraphQL.Models;

public partial class Appointment
{
    public Guid Id { get; set; }

    public string? Reason { get; set; }

    public DateTime? AppointmentDate { get; set; }

    public Guid? LawyerId { get; set; }

    public Guid? UserId { get; set; }

    public bool? IsAccept { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual Lawyer? Lawyer { get; set; }

    public virtual User? User { get; set; }
}
