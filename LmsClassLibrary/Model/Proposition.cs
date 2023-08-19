using System.ComponentModel.DataAnnotations;

namespace LmsClassLibrary.Model;

public class Proposition
{
    [Key] public int EduPropositionId { get; set; }

    public string EduSpan { get; set; }

    public string EduType { get; set; }

    public string StudentType { get; set; }

    public string EduLanguage { get; set; }

    public string EnrollmentNumber { get; set; }

    public string EnrollmentType { get; set; }

    public decimal StaffCoeff { get; set; }

    public int DepartmentId { get; set; }

    public int AcadDegreeId { get; set; }

    public int DirectionId { get; set; }

    public int SpecialityId { get; set; }

    public int EduProgramId { get; set; }
    public Department Department { get; set; }
    public Degree Degree { get; set; }
    public Speciality Speciality { get; set; }
    public Programme Programme { get; set; }
}