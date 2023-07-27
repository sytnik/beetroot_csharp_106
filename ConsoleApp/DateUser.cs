namespace ConsoleApp;

public class DateUser
{
    public DateOnly BirthDate { get; set; }
    public DateUser(int year, int month, int day) => BirthDate = new DateOnly(year, month, day);
}