using System;
using System.Collections.Generic;

namespace GraphQL.Models;

public partial class Lawyer
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Education { get; set; }

    public int? Experience { get; set; }

    public string? MobileNo { get; set; }

    public string? Description { get; set; }

    public bool? IsAvailable { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
