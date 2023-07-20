namespace LmsClassLibrary.Model;

public class Proposition
{
    public int EduPropositionId { get; set; }

    public string EduSpan { get; set; } = null!;

    public string EduType { get; set; } = null!;

    public string StudentType { get; set; } = null!;

    public string EduLanguage { get; set; } = null!;

    public string EnrollmentNumber { get; set; } = null!;

    public string EnrollmentType { get; set; } = null!;

    public decimal StaffCoeff { get; set; }

    public int DepartmentId { get; set; }

    public int AcadDegreeId { get; set; }

    public int DirectionId { get; set; }

    public int SpecialityId { get; set; }

    public int EduProgramId { get; set; }
}
