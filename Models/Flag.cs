using System;
using System.Collections.Generic;

namespace GraphQL.Models;

public partial class Flag
{
    public Guid Id { get; set; }

    public bool? IsPost { get; set; }

    public bool? IsComment { get; set; }

    public Guid? PostId { get; set; }

    public Guid? FlaggedUserId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? CommentId { get; set; }

    public virtual PostComment? Comment { get; set; }

    public virtual User? FlaggedUser { get; set; }

    public virtual Post? Post { get; set; }
}
