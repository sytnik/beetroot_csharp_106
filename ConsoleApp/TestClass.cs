namespace ConsoleApp;

public class TestClass : IEquatable<TestClass>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public bool Equals(TestClass? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id && Name == other.Name;
    }
}