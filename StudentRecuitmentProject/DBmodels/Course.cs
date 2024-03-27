using System;
using System.Collections.Generic;

namespace StudentRecuitmentProject.DBmodels;

public partial class Course
{
    public int CourseId { get; set; }

    public string? CourseName { get; set; }

    public string? Department { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<AcademicHistory> AcademicHistories { get; set; } = new List<AcademicHistory>();

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
