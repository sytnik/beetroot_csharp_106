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
        var allDepartments =
            faculties.SelectMany(faculty => faculty.Departments)
                .Distinct()
                // .OrderBy(department => department.Id)
                // .ThenBy(department => department.Name)
                .OrderByDescending(department => department.Id)
                .ThenByDescending(department => department.Name)
                .Reverse()
                .ToList();
    }
}