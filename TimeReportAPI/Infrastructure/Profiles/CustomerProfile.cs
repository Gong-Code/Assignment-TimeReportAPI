using AutoMapper;
using TimeReportAPI.Data;
using TimeReportAPI.DTO;

namespace TimeReportAPI.Infrastructure.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, List<CustomerDTO>>().ReverseMap();
            CreateMap<Customer, CustomerEditDTO>().ReverseMap();
        }
    }
}
