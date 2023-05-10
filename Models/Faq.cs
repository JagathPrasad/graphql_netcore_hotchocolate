using System;
using System.Collections.Generic;

namespace GraphQL.Models;

public partial class Faq
{
    public Guid Id { get; set; }

    public string? Question { get; set; }

    public string? Answer { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }
}
