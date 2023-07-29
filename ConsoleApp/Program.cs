using LmsClassLibrary.Dto;

namespace ConsoleApp;

public class Program
{
    public static void Main()
    {
        // var department = new Department(1, 1, "Department");
        // Department.PrintData(department.Id, department.Number, department.Name);
        DoSomething();
        var someString = "Hello World!";
        var isempty = someString.OurIsNullOrEmpty();
        var isempty1 = Sample.OurIsNullOrEmpty(someString);
        var valueFromSample = SomeValue;
        var structure = InitData();
        // (1-100)
        var faculties =
                structure.Faculties
            // .Where(faculty => faculty.Departments.Count > 5)
            // .Skip(5).Take(5)
            // .SkipWhile(f => f.Id < 21)
            // .TakeWhile(f => f.Id < 41)
            ;
        // .OfType<Department>()
        var result = faculties.ToArray();
        var facultyIds = faculties.Select(faculty =>
            new ValueTuple<int, string>(faculty.Id, faculty.Name)).ToArray();
        // var allDepartments =
        //     faculties.SelectMany(faculty => faculty.Departments)
        //         .Distinct()
        //         // .OrderBy(department => department.Id)
        //         // .ThenBy(department => department.Name)
        //         .OrderByDescending(department => department.Id)
        //         .ThenByDescending(department => department.Name)
        //         .Reverse()
        //         .ToList();
        var distinctFaculties = faculties
            .DistinctBy(f => new {f.Id, f.Name}).ToList();
        var maxFacultyId = faculties.Max(faculty => faculty.Id);
        var minFacultyId = faculties.Min(faculty => faculty.Id);
        var maxbyId = faculties.MaxBy(faculty => faculty.Id);
        var minbyId = faculties.MinBy(faculty => faculty.Id);
        var anyAbove50 = faculties.Any(faculty => faculty.Id > 50);
        var anyabove100 = faculties.Any(faculty => faculty.Id > 100);
        var allAbove50 = faculties.All(faculty => faculty.Id > 50);
        var allAbove0 = faculties.All(faculty => faculty.Id > 0);

        var allDepartments =
            faculties.SelectMany(faculty => faculty.Departments).ToList();
        var groupById =
            allDepartments.GroupBy(department => department.Id).ToList();
        var idAndCount = groupById
            .OrderBy(grouping => grouping.Key)
            .Select(grouping =>
                new ValueTuple<int, int>(grouping.Key, grouping.Count())).ToList();
        var facultywithidone = faculties.First(faculty => faculty.Id == 1);
        var departmentwithidone =
            allDepartments.FirstOrDefault(department => department.Id == 300);
        if (departmentwithidone is not null)
        {
            //  your code
        }
        
        var facultiesThirtyPlus = structure.FacultiesWithIdMoreThan(30);
    }
    
    

}