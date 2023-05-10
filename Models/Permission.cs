using System;
using System.Collections.Generic;

namespace GraphQL.Models;

public partial class Permission
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public bool? Home { get; set; }

    public bool? Journey { get; set; }

    public bool? Faq { get; set; }

    public bool? Setting { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual User? User { get; set; }
}
