namespace ShopLibrary.Dto;

public sealed class CustomerDto(int id, string name, string address)
{
    public readonly int Id = id;
    public string Name = name;
    public string Address = address;
}