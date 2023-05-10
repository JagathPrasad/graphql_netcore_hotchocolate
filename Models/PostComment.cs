using System;
using System.Collections.Generic;

namespace GraphQL.Models;

public partial class PostComment
{
    public Guid Id { get; set; }

    public string? Comment { get; set; }

    public string? Image { get; set; }

    public string? Reaction { get; set; }

    public Guid? PostId { get; set; }

    public Guid? CommentUserId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? GroupId { get; set; }

    public virtual User? CommentUser { get; set; }

    public virtual ICollection<Flag> Flags { get; set; } = new List<Flag>();

    public virtual Post? Post { get; set; }
}
