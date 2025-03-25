using faig.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace faig.Data.Repositories
{
    public class RepositoryManager:IRepositoryManager
    {
        private readonly DataContext _context;
        public IUserRepository Users { get; }
        public IPresenceRepository Presence { get; }

        public RepositoryManager(DataContext context, IUserRepository users, IPresenceRepository presence)
        {
            _context = context;
            Users = users;
            Presence = presence;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
