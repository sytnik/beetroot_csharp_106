using Microsoft.EntityFrameworkCore;
using ShopLibrary.Dbo;
using ShopLibrary.Dto;

namespace MvcApplication.Logic;

// public static class Config
// {
//     public static void SetupApis(this IEndpointRouteBuilder application)
//     {
//         application.MapGet("/customers", (ShopContext context) =>
//             context.Customer
//                 .Select(customer =>
//                     new CustomerDto(customer.Id, customer.Name, customer.Address))
//                 .ToArrayAsync());
//         application.MapGet("/customers/{id:int}", async (int id, ShopContext context) =>
//         {
//             var dto = await context.Customer
//                 .Select(customer =>
//                     new CustomerDto(customer.Id, customer.Name, customer.Address))
//                 .FirstOrDefaultAsync(customer => customer.Id == id);
//             return dto is null ? Results.NotFound($"Customer with ID {id} not found.") : Results.Ok(dto);
//         });
//         application.MapPost("/customers",
//             async (CustomerDto customer, ShopContext context) =>
//             {
//                 await context.Customer.AddAsync(new Customer()
//                 {
//                     Id = customer.Id,
//                     Name = customer.Name,
//                     Address = customer.Address
//                 });
//                 await context.SaveChangesAsync();
//                 return customer;
//             });
//         application.MapPut("/customers/{id:int}",
//             async (int id, CustomerDto customerDto, ShopContext context) =>
//             {
//                 var customerToUpdate = await context.Customer
//                     .FirstOrDefaultAsync(customer => customer.Id == id);
//                 if (customerToUpdate is not null)
//                 {
//                     customerToUpdate.Name = customerDto.Name;
//                     customerToUpdate.Address = customerDto.Address;
//                 }
//
//                 await context.SaveChangesAsync();
//                 return customerDto;
//             });
//         application.MapDelete("/customers/{id:int}", async (int id, ShopContext context) =>
//         {
//             var customer = await context.Customer
//                 .FirstOrDefaultAsync(customer => customer.Id == id);
//             if (customer is null) return;
//             context.Customer.Remove(customer);
//             await context.SaveChangesAsync();
//         });
//     }
// }