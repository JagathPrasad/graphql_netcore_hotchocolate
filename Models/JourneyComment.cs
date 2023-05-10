using System;
using System.Collections.Generic;

namespace GraphQL.Models;

public partial class JourneyComment
{
    public Guid Id { get; set; }

    public string? Comments { get; set; }

    public Guid? CommentUserId { get; set; }

    public int? JourneyId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? GroupId { get; set; }

    public virtual User? CommentUser { get; set; }

    public virtual Journey? Journey { get; set; }

    public virtual ICollection<JourneyReaction> JourneyReactions { get; set; } = new List<JourneyReaction>();
}
