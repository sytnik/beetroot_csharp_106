namespace LmsClassLibrary.Model;

public class MyCollection
{
    private int[] data = new int[10];

    public int this[int index]
    {
        get { return data[index]; }
        set { data[index] = value; }
    }
}
