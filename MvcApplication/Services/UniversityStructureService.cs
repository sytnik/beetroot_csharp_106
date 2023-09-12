using LmsClassLibrary.Model;
using Microsoft.EntityFrameworkCore;
using MvcApplication.Logic;

namespace MvcApplication.Services;

public sealed class UniversityStructureService : IUniversityStructureService
{
    private readonly EposContext _context;

    public UniversityStructureService(EposContext context) =>
        _context = context;

    public UniversityStructureService()
    {
    }

    public Task<Faculty[]> GetFaculties()
    {
        var facultiesWhere = _context.Faculty
            .Where(faculty => faculty.Name.Contains("a"));
        var facultiesOrderBy =
            facultiesWhere.OrderBy(faculty => faculty.Name);
        return facultiesOrderBy.ToArrayAsync();
    }

    public Task<Department[]> GetDepartments() =>
        _context.Department.ToArrayAsync();

    public Task<Speciality[]> GetSpecialities() =>
        _context.Speciality.ToArrayAsync();
}