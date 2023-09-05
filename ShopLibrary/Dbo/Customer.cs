namespace ShopLibrary.Dbo;

public sealed class Customer : EntityWithId
{
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Order> Orders { get; set; }
}