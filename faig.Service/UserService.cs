using faig.Core.Entities;
using faig.Core.Repositories;
using faig.Core.Services;

namespace faig.Service
{
    public class UserService : IUserService

    {
        private readonly IUserRepository _userRepository;
        private readonly IRepositoryManager _repositoryManager;

        public UserService(IUserRepository userRepository, IRepositoryManager repositoryManager) 
        {          
            _userRepository = userRepository;
            _repositoryManager = repositoryManager;
        }



        public async Task<List<User>> GetListAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task< User?> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> AddAsync(User user)
        {
            var addUser=await _userRepository.AddAsync(user);
            await _repositoryManager.SaveAsync();
            return addUser;
        }

        public async Task<User> UpdateAsync(User user)
        {
            var updateUser=await _userRepository.UpdateAsync(user);
           await _repositoryManager.SaveAsync();
            return updateUser;
        }

        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
           await _repositoryManager.SaveAsync();
        }
        public async Task<User?> GetByUserNamePasswordAsync(string name, string password)
        {
            return await _userRepository.GetByUserNamePasswordAsync(name, password);
        }

    }

   
}