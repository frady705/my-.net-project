using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace faig.Core.Repositories
{
    public interface IRepositoryManager
    {
        IUserRepository Users { get; }
        IPresenceRepository Presence { get; }
        void Save();
    }
}
