using System;
using System.Collections.Generic;

namespace StudentRecuitmentProject.DBmodels;

public partial class Student
{
    public int StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Region { get; set; } = null!;

    public DateOnly Birthday { get; set; }

    public string Program { get; set; } = null!;

    public bool Gender { get; set; }

    public virtual ICollection<AcademicHistory> AcademicHistories { get; set; } = new List<AcademicHistory>();

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
