using System;
using System.Collections.Generic;

namespace GraphQL.Models;

public partial class Notification
{
    public Guid Id { get; set; }

    public string? MobileAddress { get; set; }

    public string? Message { get; set; }

    public string? MobileNo { get; set; }

    public Guid? UserId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public virtual User? User { get; set; }
}
