namespace LmsClassLibrary.Model;

public class ExcelGroup
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int FacultyId { get; set; }
    public int DepartmentId { get; set; }
    public int SpecialityId { get; set; }
    public string SpecialityName { get; set; }
    public int Course { get; set; }
    
    public ExcelGroup(string name, int facultyId, int departmentId, int specialityId, string specialityName, int course)
    {
        Name = name;
        FacultyId = facultyId;
        DepartmentId = departmentId;
        SpecialityId = specialityId;
        SpecialityName = specialityName;
        Course = course;
    }
}