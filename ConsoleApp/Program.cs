using System.Reflection;
using LmsClassLibrary.Dto;

namespace ConsoleApp;

public class Program
{
    public static void Main()
    {
        var assembly = Assembly.LoadFrom("LmsClassLibrary.dll");
        var structDtoType = assembly.GetType("LmsClassLibrary.Dto.StructureDto");
        var structDtoInstance =
            (StructureDto) Activator.CreateInstance(structDtoType, new object[] {10});
        var prop =
            structDtoType.GetProperty("PrivateFaculties",
                BindingFlags.NonPublic | BindingFlags.Instance);
        prop.SetValue(structDtoInstance, Sample.InitData(100).Faculties);
        var structDtoInstanceFaculties = (List<Faculty>)
            prop.GetValue(structDtoInstance);
        var methods = structDtoType.GetMethods();
        var fields = structDtoType.GetFields();
        var properties =
            structDtoType.GetProperties(BindingFlags.Public |
                                        BindingFlags.NonPublic |
                                        BindingFlags.Instance);
        var constructors = structDtoType.GetConstructors();
        var interfaces = structDtoType.GetInterfaces();
        var isClass = structDtoType.IsClass;
        var isInterface = structDtoType.IsInterface;
        var isValueType = structDtoType.IsValueType;
        var isAbstract = structDtoType.IsAbstract;
        var isEnum = structDtoType.IsEnum;
        var isPrimitive = structDtoType.IsPrimitive;
        var isPublic = structDtoType.IsPublic;
        var isSealed = structDtoType.IsSealed;
        var isSerializable = structDtoType.IsSerializable;
        var isSpecialName = structDtoType.IsSpecialName;
        var isNested = structDtoType.IsNested;

        var secondInstance =
            Activator.CreateInstance(structDtoType,
                new object[] {structDtoInstance.Faculties});
    }
}