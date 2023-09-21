using Microsoft.EntityFrameworkCore;
using ShopLibrary.Dbo;
using ShopLibrary.Dto;

namespace ShopLibrary;

public class ShopService(ShopContext shopContext):IShopService
{
    public Task<CustomerDto[]> GetCustomers() =>
        shopContext.Customer
            .Select(customer =>
                new CustomerDto(customer.Id, customer.Name, customer.Address))
            .ToArrayAsync();

    public Task<CustomerDto> GetCustomer(int id) =>
        shopContext.Customer
            .Select(customer =>
                new CustomerDto(customer.Id, customer.Name, customer.Address))
            .FirstOrDefaultAsync(customer => customer.Id == id);
    
    public Task<CustomerDto> UpdateCustomer(CustomerDto customerDto) =>
        shopContext.Customer
            .FirstOrDefaultAsync(customer => customer.Id == customerDto.Id)
        .ContinueWith(task =>
        {
            var customer = task.Result;
            customer.Name = customerDto.Name;
            customer.Address = customerDto.Address;
            return customer;
        })
        .ContinueWith(task =>
        {
            shopContext.Customer.Update(task.Result);
            return task.Result;
        })
        .ContinueWith(_ => shopContext.SaveChangesAsync())
        .ContinueWith(_ => customerDto);
}