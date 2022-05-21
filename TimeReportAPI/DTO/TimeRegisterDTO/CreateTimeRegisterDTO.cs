using System.ComponentModel.DataAnnotations;

namespace TimeReportAPI.DTO.TimeRegisterDTO
{
    public class CreateTimeRegisterDTO
    {  
        public int Hours { get; set; }

        public int Minutes { get; set; }

        public int ProjectId { get; set; }

    }
}
