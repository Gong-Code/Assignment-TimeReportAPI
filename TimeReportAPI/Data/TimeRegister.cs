using System.Reflection.Metadata.Ecma335;

namespace TimeReportAPI.Data
{
    public class TimeRegister
    {
        public int TimeRegisterId { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public Project? Project { get; set; }

    }
}
