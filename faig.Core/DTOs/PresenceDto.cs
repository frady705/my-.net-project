using faig.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace faig.Core.DTOs
{
    public class PresenceDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }

        public DateTime Date { get; set; }
        public string EntryTime { get; set; }
        public string DepartureTime { get; set; }
        public string AttendanceStatus { get; set; }

    }
}
