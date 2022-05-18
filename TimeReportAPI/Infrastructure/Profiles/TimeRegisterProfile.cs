using AutoMapper;
using TimeReportAPI.Data;
using TimeReportAPI.DTO;
using TimeReportAPI.DTO.TimeRegisterDTO;

namespace TimeReportAPI.Infrastructure.Profiles
{
    public class TimeRegisterProfile : Profile
    {
        public TimeRegisterProfile()
        {
            CreateMap<TimeRegister, GetAllTimeRegisterDTO>().ForMember(p => p.ProjectId, act => act.MapFrom(src => src.Project.ProjectId)).ReverseMap();
            CreateMap<TimeRegister, GetOneTimeRegisterDTO>().ForMember(p => p.ProjectId, act => act.MapFrom(src => src.Project.ProjectId)).ReverseMap();
            CreateMap<TimeRegister, CreateTimeRegisterDTO>().ForMember(p => p.ProjectId, act => act.MapFrom(src => src.Project.ProjectId)).ReverseMap();
            CreateMap<TimeRegister, UpdateTimeRegisterDTO>().ReverseMap();
        }
    }
}
