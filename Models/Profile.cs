using System;
using System.Collections.Generic;

namespace GraphQL.Models;

public partial class Profile
{
    public Guid Id { get; set; }

    public string? UniversityName { get; set; }

    public string? EmployerName { get; set; }

    public bool? IsUsa { get; set; }

    public DateTime? VisaStartDate { get; set; }

    public DateTime? VisaEndDate { get; set; }

    public DateTime? PassportExpiryDate { get; set; }

    public Guid? UserId { get; set; }

    public int? VisaTypeId { get; set; }

    public string? PostTopicId { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public DateTime? CreatedOn { get; set; }

    public Guid? CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual User? User { get; set; }

    public virtual VisaType? VisaType { get; set; }
}
