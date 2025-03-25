using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace faig.Core.Entities
{
    public class Presence
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan EntryTime { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public string AttendanceStatus { get; set; }

        public Presence()
        {
            Date = Date.Date;
        }
    }
}
