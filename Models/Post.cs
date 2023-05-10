using System;
using System.Collections.Generic;

namespace GraphQL.Models;

public partial class Post
{
    public Guid Id { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public string? Hashtag { get; set; }

    public string? TagUser { get; set; }

    public bool? IsReaction { get; set; }

    public bool? IsTrending { get; set; }

    public int? Ranking { get; set; }

    public bool? IsEdit { get; set; }

    public bool? IsCommon { get; set; }

    public Guid? UserId { get; set; }

    public int? PostTypeId { get; set; }

    public int? PostTopicId { get; set; }

    public int? CommunityId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool? IsAnonymous { get; set; }

    public virtual Community? Community { get; set; }

    public virtual ICollection<Flag> Flags { get; set; } = new List<Flag>();

    public virtual ICollection<PostComment> PostComments { get; set; } = new List<PostComment>();

    public virtual ICollection<PostReaction> PostReactions { get; set; } = new List<PostReaction>();

    public virtual PostTopic? PostTopic { get; set; }

    public virtual PostType? PostType { get; set; }

    public virtual ICollection<Share> Shares { get; set; } = new List<Share>();

    public virtual User? User { get; set; }

    public virtual ICollection<View> Views { get; set; } = new List<View>();
}
