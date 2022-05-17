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
            CreateMap<Project, GetAllProjectDTO>().ReverseMap();
            CreateMap<Project, GetOneProjectDTO>().ReverseMap();
            CreateMap<Project, CreateProjectDTO>().ReverseMap();
            CreateMap<Project, UpdateProjectDTO>().ReverseMap();
        }
    }
}
