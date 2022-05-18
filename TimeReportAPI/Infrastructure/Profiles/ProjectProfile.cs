using AutoMapper;
using TimeReportAPI.Data;
using TimeReportAPI.DTO.ProjectDTO;
using TimeReportAPI.DTO;

namespace TimeReportAPI.Infrastructure.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, GetAllProjectDTO>().ForMember(c => c.CustomerId, act => act.MapFrom(src => src.Customer.CustomerId)).ReverseMap();
            CreateMap<Project, GetOneProjectDTO>().ForMember(c => c.CustomerId, act => act.MapFrom(src => src.Customer.CustomerId)).ReverseMap();
            CreateMap<Project, CreateProjectDTO>().ForMember(c => c.CustomerId, act => act.MapFrom(src => src.Customer.CustomerId)).ReverseMap();
            CreateMap<Project, UpdateProjectDTO>().ReverseMap();
        }
    }
}
