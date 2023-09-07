using LmsClassLibrary.Model;
using MvcApplication.Logic;

namespace MvcApplication.Services;

public class UniversityStructureService
{
    private readonly EposContext _context;
    public UniversityStructureService(EposContext context) =>
        _context = context;
    
    public Faculty[] GetFaculties() =>
        _context.Faculty.ToArray();
    public Department[] GetDepartments() =>
        _context.Department.ToArray();
    public Speciality[] GetSpecialities() =>
        _context.Speciality.ToArray();
}