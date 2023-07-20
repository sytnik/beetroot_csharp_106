namespace ConsoleApp;

public class DerivedClass: BaseClass, IEquatable<DerivedClass>, IComparable<DerivedClass>
{
    public string Name { get; set; }

    public bool Equals(DerivedClass? other)
    {
        if (other is null) return false;
        return Id == other.Id && Name.Length == other.Name.Length;
    }

    public int CompareTo(DerivedClass? other)
    {
        if (other is null) return 1;
        return Id.CompareTo(other.Id);
    }
}