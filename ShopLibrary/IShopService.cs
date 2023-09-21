using ShopLibrary.Dto;

namespace ShopLibrary;

public interface IShopService
{
    Task<CustomerDto[]> GetCustomers();
    Task<CustomerDto> GetCustomer(int id);
    Task<CustomerDto> UpdateCustomer(CustomerDto customerDto);
}