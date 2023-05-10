﻿using System;
using System.Collections.Generic;

namespace GraphQL.Models;

public partial class UserCommunity
{
    public Guid Id { get; set; }

    public int? CommunityId { get; set; }

    public Guid? UserId { get; set; }

    public bool? IsAccept { get; set; }

    public bool? IsPrivate { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual Community? Community { get; set; }

    public virtual User? User { get; set; }
}
