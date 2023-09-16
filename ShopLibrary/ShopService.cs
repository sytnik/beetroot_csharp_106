using Microsoft.EntityFrameworkCore;
using ShopLibrary.Dbo;
using ShopLibrary.Dto;

namespace ShopLibrary;

public class ShopService
{
    private readonly ShopContext _shopContext;
    public ShopService(ShopContext shopContext) => _shopContext = shopContext;

    public Task<CustomerDto[]> GetCustomers() =>
        _shopContext.Customer
            .Select(customer =>
                new CustomerDto(customer.Id, customer.Name, customer.Address))
            .ToArrayAsync();
}