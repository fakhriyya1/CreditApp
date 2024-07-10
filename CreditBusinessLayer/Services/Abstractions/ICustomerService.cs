using CreditEntityLayer.DTOs.Customer;
using CreditEntityLayer.Entities;

namespace CreditBusinessLayer.Services.Abstractions
{
	public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
        Task<CustomerDetailsDto?> GetCustomerByIdAsync(int? id);
        Task CreateCustomerAsync(CustomerAddDto customerAdd);
        Task<Customer?> Exists(CustomerAddDto customerAdd);
    }
}
