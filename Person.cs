namespace beetroot_csharp_106;

class Person
{
    string Name;
    int Age { get; set; }
    
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}