namespace ShopLibrary.Dbo;

public class Order : EntityWithId
{
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public DateTime Date { get;set; }
    public List<Product> Products { get; set; }
    public List<OrderProduct> OrderProducts { get; set; }
}