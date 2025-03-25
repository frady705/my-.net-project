using faig.Core.Entities;

namespace faig.API.Models
{
    public class PresencePostModel
    {
        public int UserId { get; set; }
        public DateTime Date{ get; set; }
        public TimeSpan EntryTime { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public string AttendanceStatus { get; set; }

        public PresencePostModel()
        {
            Date = Date.Date;
        }
    }
}
