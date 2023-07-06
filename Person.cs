namespace beetroot_csharp_106;

class Person
{
    string Name;

    private int _Age;

    int Age
    {
        get
        {
            if (_Age < 0)
                throw new FormatException("Age cannot be less than 0");
            return _Age;
        }
        set
        {
            if (value < 0)
                throw new FormatException("Age cannot be less than 0");
        }
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}