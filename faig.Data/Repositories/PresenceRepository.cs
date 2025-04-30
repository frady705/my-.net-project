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
        public async Task< List<Presence>> GetAllAsync()
        {
            return await _context.Presence.ToListAsync();
        }

        public async Task<Presence?> GetByIdAsync(int id)
        {
            return await _context.Presence.FirstOrDefaultAsync(x => x.Id == id);

        }
        public async Task<Presence> AddAsync(Presence presence)
        {
           await _context.Presence.AddAsync(presence);
            return presence;
        }

        public async Task<Presence> UpdateAsync(Presence presence)
        {
            var existingPresence = await GetByIdAsync(presence.Id);
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

        public async Task DeleteAsync(int id)
        {
            var existingPresence =await GetByIdAsync(id);
            if (existingPresence is not null)
            {
                _context.Presence.ToList().Remove(existingPresence);
            }
        }
        
    }

}
