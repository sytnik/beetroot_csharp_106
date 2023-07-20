namespace LmsClassLibrary.Model;

public readonly struct TestStruct
{
    public TestStruct()
    {
    }

    public TestStruct(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; init; }
    public string Name { get; init; } = "Default name";

    public override string ToString() =>
        $"My struct: Id: {Id}, Name: {Name}";
}