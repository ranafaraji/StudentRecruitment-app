using System;
using System.Collections.Generic;

namespace StudentRecuitmentProject.DBmodels;

public partial class Application
{
    public int ApplicationId { get; set; }

    public int? StudentId { get; set; }

    public int? CourseId { get; set; }

    public DateOnly? ApplicationDate { get; set; }

    public string? Status { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Student? Student { get; set; }
}
