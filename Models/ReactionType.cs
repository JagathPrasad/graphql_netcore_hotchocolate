using System;
using System.Collections.Generic;

namespace GraphQL.Models;

public partial class ReactionType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<JourneyReaction> JourneyReactions { get; set; } = new List<JourneyReaction>();

    public virtual ICollection<PostReaction> PostReactions { get; set; } = new List<PostReaction>();
}
