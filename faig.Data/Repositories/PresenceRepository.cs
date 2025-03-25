using faig.Core.Entities;
using faig.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace faig.Data.Repositories
{
    public class PresenceRepository: IPresenceRepository
    {
        private readonly DataContext _context;
        public PresenceRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Presence> GetList()
        {
            return _context.Presence.Include(u => u.User);
        }
        public List<Presence> GetAll()
        {
            return _context.Presence.ToList();
        }

        public Presence? GetById(int id)
        {
            return _context.Presence.ToList().FirstOrDefault(x => x.Id == id);

        }
        public Presence Add(Presence presence)
        {
            _context.Presence.Add(presence);
            return presence;
        }

        public Presence Update(Presence presence)
        {
            var existingPresence = GetById(presence.Id);
            if (existingPresence is null)
            {
                throw new Exception("presence not found");
            }
            existingPresence.Date = presence.Date;
            existingPresence.EntryTime = presence.EntryTime;
            existingPresence.DepartureTime = presence.DepartureTime;
            existingPresence.AttendanceStatus = presence.AttendanceStatus;
            return existingPresence;
        }

        public void Delete(int id)
        {
            var existingPresence = GetById(id);
            if (existingPresence is not null)
            {
                _context.Presence.ToList().Remove(existingPresence);
            }
        }

    }
}
