using System.Xml.Serialization;
using LmsClassLibrary.Dto;
using Newtonsoft.Json;
using SysTextJson = System.Text.Json.JsonSerializer;

namespace ConsoleApp;

public class Program
{
    public static void Main()
    {
        var faculties = InitData(100);
        var departments = faculties.FacultiesWithIdMoreThan(50);
        // ToXml(faculties, "structureDto.xml");
        // ToXml(departments, "departments.xml");
        // var faculties2 = FromXml<StructureDto>("structureDto.xml");
        // var departments2 =
        //     FromXml<FacultyIdNameDto[]>("departments.xml");
        ToJsonSystemText(faculties, "structureDto1.json");
        var faculties2 = FromJsonSystemText<StructureDto>("structureDto1.json");
        
        
        
    }

    public static void ToXml<T>(T data, string fileName)
    {
        var serializer = new XmlSerializer(typeof(T));
        using var writer = new StreamWriter(fileName);
        serializer.Serialize(writer, data);
    }

    public static T FromXml<T>(string fileName)
    {
        var serializer = new XmlSerializer(typeof(T));
        using var reader = new StreamReader(fileName);
        return (T) serializer.Deserialize(reader);
    }
    
    public static void ToJsonNewtonsoft<T>(T data, string fileName) =>
        File.WriteAllText(fileName, JsonConvert.SerializeObject(data));
    
    public static T FromJsonNewtonsoft<T>(string fileName) =>
        JsonConvert.DeserializeObject<T>(File.ReadAllText(fileName));
    
    public static void ToJsonSystemText<T>(T data, string fileName) =>
        File.WriteAllText(fileName, SysTextJson.Serialize(data));
    
    public static T FromJsonSystemText<T>(string fileName) =>
        SysTextJson.Deserialize<T>(File.ReadAllText(fileName));
    
    public static async Task ToJsonAsyncSystemText<T>(T data, string fileName) =>
        await File.WriteAllTextAsync(fileName, SysTextJson.Serialize(data));
    
    public static async Task<T> FromJsonAsyncSystemText<T>(string fileName) =>
        SysTextJson.Deserialize<T>(await File.ReadAllTextAsync(fileName));
}