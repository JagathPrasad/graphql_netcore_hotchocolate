using System;
using System.Collections.Generic;

namespace GraphQL.Models;

public partial class Follow
{
    public Guid Id { get; set; }

    public Guid? UserId { get; set; }

    public Guid? FollowUserId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual User? FollowUser { get; set; }

    public virtual User? User { get; set; }
}
