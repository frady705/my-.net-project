using faig.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace faig.Core.Services
{
    public interface IPresenceService
    {
        List<Presence> GetList();

        Presence? GetById(int id);

        Presence Add(Presence presence);

        Presence Update(Presence presence);

        void Delete(int id);
    }
}
