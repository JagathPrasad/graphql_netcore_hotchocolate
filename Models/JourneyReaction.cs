using System;
using System.Collections.Generic;

namespace GraphQL.Models;

public partial class JourneyReaction
{
    public Guid Id { get; set; }

    public int? ReactionTypeId { get; set; }

    public int? JourneyId { get; set; }

    public Guid? ReactionUserId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? JourneyCommentId { get; set; }

    public virtual Journey? Journey { get; set; }

    public virtual JourneyComment? JourneyComment { get; set; }

    public virtual ReactionType? ReactionType { get; set; }

    public virtual User? ReactionUser { get; set; }
}
