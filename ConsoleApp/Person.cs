namespace ConsoleApp;

public class Person
{
    private string _Name;
    
    public string Name
    {
        get => $"Name: {_Name}";
        set
        {
            if(value.Length < 3)
                throw new FormatException("Name cannot be less than 3 characters");
        }
    }

    private int _Age;

    public int Age
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