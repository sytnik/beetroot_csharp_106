using Bogus;
using LmsClassLibrary.Dto;
using LmsClassLibrary.Model;

namespace LmsClassLibrary.Util;

public static class Sample
{
    public static string SomeValue = "Hello World!";

    public static void DoSomething()
    {
        Console.WriteLine(SomeValue);
    }

    public static bool OurIsNullOrEmpty(this string value)
        => string.IsNullOrEmpty(value);

    public static StructureDto InitData()
    {
        var departmentFaker = new Faker<Department>()
            .RuleFor(d => d.Id, faker => faker.IndexFaker + 1)
            .RuleFor(d => d.Number, faker => faker.IndexFaker + 1)
            .RuleFor(d => d.Name, faker => faker.Company.CompanyName())
            .RuleFor(d => d.Slug, (faker, department) =>
                department.Name.Replace(" ", "-").ToLower());
        var departments = departmentFaker.Generate(300);
        var facultyFaker = new Faker<Faculty>()
            .RuleFor(faculty => faculty.Id, faker => faker.IndexFaker + 1)
            .RuleFor(faculty => faculty.Number, faker => faker.IndexFaker + 1)
            .RuleFor(faculty => faculty.Name, faker => faker.Company.CompanyName())
            .RuleFor(faculty => faculty.Slug, (faker, faculty) =>
                faculty.Name.Replace(" ", "-").ToLower())
            .RuleFor(faculty => faculty.Info, faker => faker.Lorem.Paragraph())
            .RuleFor(faculty => faculty.Departments, faker =>
                faker.PickRandom(departments, faker.Random.Int(3, 10)).ToList());
        var faculties = facultyFaker.Generate(100);
        return new StructureDto(faculties);
    }

    public static FacultyIdNameDto[] FacultiesWithIdMoreThan(this StructureDto dto, int id) =>
        dto
            .Faculties
            .Where(faculty => faculty.Id > id)
            .OrderBy(faculty => faculty.Id)
            .ThenBy(faculty => faculty.Name)
            .Select(faculty => new FacultyIdNameDto(
                faculty.Id,
                faculty.Name,
                faculty.Departments.Select(department =>
                        new DepartmentIdNameSlugDto(
                            department.Id,
                            department.Name,
                            department.Slug))
                    .ToArray()
            ))
            .ToArray();
}