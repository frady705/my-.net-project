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



        public List<User> GetList()
        {
            return _userRepository.GetAll();
        }

        public User? GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User Add(User user)
        {
            var addUser=_userRepository.Add(user);
            _repositoryManager.Save();
            return addUser;
        }

        public User Update(User user)
        {
            var updateUser=_userRepository.Update(user);
            _repositoryManager.Save();
            return updateUser;
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
            _repositoryManager.Save();
        }

      
    }

   
}