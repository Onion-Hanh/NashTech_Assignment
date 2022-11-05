using API.Models;
using AutoMapper;
using CommonModel.Customer;

namespace API.Mapping
{
    public class Customer_Mapping : Profile
    {
        public Customer_Mapping()
        {
            CreateMap<Customer, CustomerDTO>();
        }
    }
}
