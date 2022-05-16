using AutoMapper;
using TimeReportAPI.Data;
using TimeReportAPI.DTO;

namespace TimeReportAPI.Infrastructure.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDTO>().ReverseMap();
            CreateMap<Project, List<ProjectDTO>>().ReverseMap();
            CreateMap<Project, ProjectEditDTO>().ReverseMap();
        }
    }
}
