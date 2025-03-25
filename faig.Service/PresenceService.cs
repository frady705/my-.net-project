using faig.Core.Entities;
using faig.Core.Repositories;
using faig.Core.Services;


namespace faig.Service
{
    public class PresenceService:IPresenceService
    {
        private readonly IPresenceRepository _presenceRepository;
        private readonly IRepositoryManager _repositoryManager;
        public PresenceService(IPresenceRepository presenceRepository, IRepositoryManager repositoryManager)
        {
            _presenceRepository = presenceRepository;
            _repositoryManager = repositoryManager;
        }
        public List<Presence> GetList()
        {
            return _presenceRepository.GetAll();
        }

        public Presence? GetById(int id)
        {
            return _presenceRepository.GetById(id);
        }

        public Presence Add(Presence presence)
        {
            var addPresence=_presenceRepository.Add(presence);
            _repositoryManager.Save();
            return addPresence;
        }

        public Presence Update(Presence presence)
        {
            var updatePresence=_presenceRepository.Update(presence);
            _repositoryManager.Save();
            return updatePresence;
        }

        public void Delete(int id)
        {
            _presenceRepository.Delete(id);
            _repositoryManager.Save();
        }

    }
}
