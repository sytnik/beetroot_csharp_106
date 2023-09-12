using LmsClassLibrary.Model;

namespace MvcApplication.Services;

public interface IUniversityStructureService
{
    Task<Faculty[]> GetFaculties();
    Task<Department[]> GetDepartments();
    Task<Speciality[]> GetSpecialities();
}