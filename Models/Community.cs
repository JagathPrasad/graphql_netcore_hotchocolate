using System;
using System.Collections.Generic;

namespace GraphQL.Models;

public partial class Community
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public Guid? CreatedBy { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<CommunityRequst> CommunityRequsts { get; set; } = new List<CommunityRequst>();

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<UserCommunity> UserCommunities { get; set; } = new List<UserCommunity>();
}
