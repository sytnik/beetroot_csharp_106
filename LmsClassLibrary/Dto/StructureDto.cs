using System.Text.Json.Serialization;
using LmsClassLibrary.Model;
using LmsClassLibrary.Util;

namespace LmsClassLibrary.Dto;

[JsonSerializable(typeof(StructureDto))]
public class StructureDto
{
    public StructureDto(List<Faculty> faculties)
    {
        Faculties = faculties;
    }
    
    public StructureDto(int count)
    {
        Faculties = Sample.InitData(count).Faculties;
    }

    [JsonIgnore]
    public List<Faculty> Faculties { get; set; }
    
    private List<Faculty> PrivateFaculties { get; set; }
}