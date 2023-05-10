using System;
using System.Collections.Generic;

namespace GraphQL.Models;

public partial class Share
{
    public Guid Id { get; set; }

    public Guid? PostId { get; set; }

    public Guid? ShareUserId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual Post? Post { get; set; }

    public virtual User? ShareUser { get; set; }
}
