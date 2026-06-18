namespace Domain.Models
{
    public class DoctorAvailability : BaseEntity<int>
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }

    public class TimeSlot
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsAvailable { get; set; }
    }
}
