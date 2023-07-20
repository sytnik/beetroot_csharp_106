namespace LmsClassLibrary.Model;

public class FullTimeVersion
{
    public int Id { get; set; }

    public short Term { get; set; }

    public decimal Credits { get; set; }

    public short LecturePerWeekFirst { get; set; }

    public short LecturePerWeekSecond { get; set; }

    public short LabWorkPerWeekFirst { get; set; }

    public short LabWorkPerWeekSecond { get; set; }

    public short PracticalWorkPerWeekFirst { get; set; }

    public short PracticalWorkPerWeekSecond { get; set; }

    public short CalcGraphWork { get; set; }

    public short CalcWork { get; set; }

    public short ControlWork { get; set; }

    public short CourseWork { get; set; }

    public short CourseProject { get; set; }

    public short Exam { get; set; }

    public short GradedTest { get; set; }

    public short Test { get; set; }

    public short LectureHoursFirst { get; set; }

    public short LectureHoursSecond { get; set; }

    public short LabWorkHoursFirst { get; set; }

    public short LabWorkHoursSecond { get; set; }

    public short PracticalWorkHoursFirst { get; set; }

    public short PracticalWorkHoursSecond { get; set; }

    public short LectureHours { get; set; }

    public short LabWorkHours { get; set; }

    public short PracticalWorkHours { get; set; }

    public short CreditHours { get; set; }

    public short AcademicHours { get; set; }

    public short IndependentWorkHours { get; set; }

    public int CycleId { get; set; }

    public int DisciplineId { get; set; }

    public int DepartmentId { get; set; }
}
