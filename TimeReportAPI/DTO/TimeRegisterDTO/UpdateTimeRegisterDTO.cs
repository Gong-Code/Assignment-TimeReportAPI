using System.ComponentModel.DataAnnotations;

namespace TimeReportAPI.DTO
{
    public class UpdateTimeRegisterDTO
    {
        [Required]
        public DateTime Date { get; set; }

        [MaxLength(24)]
        [Required]
        public int Hours { get; set; }

        [MaxLength(60)]
        [Required]
        public int Minutes { get; set; }
    }
}
