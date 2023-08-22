namespace LmsClassLibrary.Dto;

public record FacultyDto(int Id, int Number, string Name, DepartmentDto[] Departments);