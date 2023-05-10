using System;
using System.Collections.Generic;

namespace GraphQL.Models;

public partial class View
{
    public Guid Id { get; set; }

    public Guid? PostId { get; set; }

    public int? ViewCount { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual Post? Post { get; set; }
}
