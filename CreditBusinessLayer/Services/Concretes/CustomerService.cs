using AutoMapper;
using CreditBusinessLayer.Services.Abstractions;
using CreditDataLayer.UnitOfWorks;
using CreditEntityLayer.DTOs.Customer;
using CreditEntityLayer.Entities;

namespace CreditBusinessLayer.Services.Concretes
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _unitOfWork.GetRepository<Customer>().GetAllAsync();

            var customerDtos = _mapper.Map<IEnumerable<CustomerDto>>(customers);

            return customerDtos;
        }

        public async Task CreateCustomerAsync(CustomerAddDto customerAdd)
        {
            var customer = _mapper.Map<Customer>(customerAdd);

            await _unitOfWork.GetRepository<Customer>().AddAsync(customer);
            await _unitOfWork.SaveAsync();
        }

        public async Task<CustomerDetailsDto?> GetCustomerByIdAsync(int? id)
        {
            var customer = await _unitOfWork.GetRepository<Customer>().GetByIdAsync((int)id);
            if (customer == null)
                return null;

            var customerDetailsDto = _mapper.Map<CustomerDetailsDto>(customer);

            return customerDetailsDto;
        }

        public async Task<Customer?> Exists(CustomerAddDto customerAdd)
        {
            var customerEntity = await _unitOfWork.GetRepository<Customer>().GetTAsync(c => c.PIN == customerAdd.PIN);
            if(customerEntity == null)
                return null;

            return customerEntity;
        }
    }
}
