namespace ConsoleApp;

public partial class TestClass
{
    public bool Equals(TestClass? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id && Name == other.Name;
    }
}