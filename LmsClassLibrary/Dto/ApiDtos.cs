namespace LmsClassLibrary.Dto;

public readonly record struct FacultyIdNameDto(
    int Id, string Name, DepartmentIdNameSlugDto[] Departments);
public readonly record struct DepartmentIdNameSlugDto(
    int Id, string Name, string Slug);