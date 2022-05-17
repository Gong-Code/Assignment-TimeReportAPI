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
            CreateMap<TimeRegister, GetAllTimeRegisterDTO>().ReverseMap();
            CreateMap<TimeRegister, GetOneTimeRegisterDTO>().ReverseMap();
            CreateMap<TimeRegister, CreateTimeRegisterDTO>().ReverseMap();
            CreateMap<TimeRegister, UpdateTimeRegisterDTO>().ReverseMap();
        }
    }
}
