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
        public async Task<List<Presence>> GetListAsync()
        {
            return await _presenceRepository.GetAllAsync();
        }

        public async Task<Presence?> GetByIdAsync(int id)
        {
            return await _presenceRepository.GetByIdAsync(id);
        }

        public async Task<Presence> AddAsync(Presence presence)
        {
            var addPresence=await _presenceRepository.AddAsync(presence);
            await _repositoryManager.SaveAsync();
            return addPresence;
        }

        public async Task<Presence> UpdateAsync(Presence presence)
        {
            var updatePresence=await _presenceRepository.UpdateAsync(presence);
            await _repositoryManager.SaveAsync();
            return updatePresence;
        }

        public async Task DeleteAsync(int id)
        {
            await _presenceRepository.DeleteAsync(id);
            await _repositoryManager.SaveAsync();
        }

    }

}
