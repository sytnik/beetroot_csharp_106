using LmsClassLibrary.Model;

namespace LmsClassLibrary.Dto;

public class StructureDto
{
    public StructureDto(List<Faculty> faculties)
    {
        Faculties = faculties;
    }

    public List<Faculty> Faculties { get; set; }
}