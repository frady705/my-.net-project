using faig.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace faig.Core.Repositories
{
    public interface IPresenceRepository
    {
        Task<List<Presence>> GetAllAsync();

       Task<Presence?> GetByIdAsync(int id);

        Task<Presence> AddAsync(Presence presence);

        Task<Presence> UpdateAsync(Presence presence);

        Task DeleteAsync(int id);
       
    }
}

