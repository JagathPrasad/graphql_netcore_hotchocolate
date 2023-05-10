using System;
using System.Collections.Generic;

namespace GraphQL.Models;

public partial class PostTopic
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
