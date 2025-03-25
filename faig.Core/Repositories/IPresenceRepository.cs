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
        List<Presence> GetAll();

       Presence? GetById(int id);

        Presence Add(Presence presence);

        Presence Update(Presence presence);

        void Delete(int id);
    }
}

