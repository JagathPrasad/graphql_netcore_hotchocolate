using System;
using System.Collections.Generic;

namespace GraphQL.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? MobileNo { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Community> Communities { get; set; } = new List<Community>();

    public virtual ICollection<CommunityRequst> CommunityRequstRequestUsers { get; set; } = new List<CommunityRequst>();

    public virtual ICollection<CommunityRequst> CommunityRequstUsers { get; set; } = new List<CommunityRequst>();

    public virtual ICollection<Flag> Flags { get; set; } = new List<Flag>();

    public virtual ICollection<Follow> FollowFollowUsers { get; set; } = new List<Follow>();

    public virtual ICollection<Follow> FollowUsers { get; set; } = new List<Follow>();

    public virtual ICollection<JourneyComment> JourneyComments { get; set; } = new List<JourneyComment>();

    public virtual ICollection<JourneyReaction> JourneyReactions { get; set; } = new List<JourneyReaction>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();

    public virtual ICollection<PostComment> PostComments { get; set; } = new List<PostComment>();

    public virtual ICollection<PostReaction> PostReactions { get; set; } = new List<PostReaction>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Profile> Profiles { get; set; } = new List<Profile>();

    public virtual ICollection<Share> Shares { get; set; } = new List<Share>();

    public virtual ICollection<UserCommunity> UserCommunities { get; set; } = new List<UserCommunity>();
}
