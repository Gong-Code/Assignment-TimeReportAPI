using AutoMapper;
using TimeReportAPI.Data;
using TimeReportAPI.DTO;
using TimeReportAPI.DTO.CustomerDTO;

namespace TimeReportAPI.Infrastructure.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, GetAllCustomerDTO>().ReverseMap();
            CreateMap<Customer, GetOneCustomerDTO>().ReverseMap();
            CreateMap<Customer, CreateCustomerDTO>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDTO>().ReverseMap();
        }
    }
}
