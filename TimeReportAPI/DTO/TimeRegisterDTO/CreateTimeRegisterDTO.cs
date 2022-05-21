using System.ComponentModel.DataAnnotations;

namespace TimeReportAPI.DTO.TimeRegisterDTO
{
    public class CreateTimeRegisterDTO
    {
        [Required]
        public DateTime Date { get; set; }

        [MaxLength(24)]
        [Required]
        public int Hours { get; set; }

        [MaxLength(60)]
        [Required]
        public int Minutes { get; set; }

        public int ProjectId { get; set; }

    }
}
