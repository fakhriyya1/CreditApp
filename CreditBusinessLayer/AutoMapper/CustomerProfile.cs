using AutoMapper;
using CreditEntityLayer.DTOs.Customer;
using CreditEntityLayer.Entities;

namespace CreditBusinessLayer.AutoMapper
{
	public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerAddDto, Customer>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<Customer, CustomerDetailsDto>();
        }
    }
}
