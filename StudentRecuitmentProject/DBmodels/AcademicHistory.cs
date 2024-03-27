using System;
using System.Collections.Generic;

namespace StudentRecuitmentProject.DBmodels;

public partial class AcademicHistory
{
    public int AcademicHistoryId { get; set; }

    public int? StudentId { get; set; }

    public int? CourseId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? Grade { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Student? Student { get; set; }
}
