using System;
using System.Collections.Generic;

namespace GraphQL.Models;

public partial class Journey
{
    public int Id { get; set; }

    public string? Steps { get; set; }

    public string? Description { get; set; }

    public int? VisaTypeId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<JourneyComment> JourneyComments { get; set; } = new List<JourneyComment>();

    public virtual ICollection<JourneyReaction> JourneyReactions { get; set; } = new List<JourneyReaction>();

    public virtual VisaType? VisaType { get; set; }
}
