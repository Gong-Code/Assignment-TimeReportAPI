using AutoMapper;
using TimeReportAPI.Data;
using TimeReportAPI.DTO;

namespace TimeReportAPI.Infrastructure.Profiles
{
    public class TimeRegisterProfile : Profile
    {
        public TimeRegisterProfile()
        {
            CreateMap<TimeRegister, TimeRegisterDTO>().ReverseMap();
            CreateMap<TimeRegister, List<TimeRegisterDTO>>().ReverseMap();
            CreateMap<TimeRegister, List<TimeRegisterEditDTO>>().ReverseMap();
        }
    }
}
