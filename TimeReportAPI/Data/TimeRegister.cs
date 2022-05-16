using System.Reflection.Metadata.Ecma335;

namespace TimeReportAPI.Data
{
    public class TimeRegister
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }

    }
}
