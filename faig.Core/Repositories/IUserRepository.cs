using faig.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace faig.Core.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();

        Task<User?> GetByIdAsync(int id);

        Task<User> AddAsync(User user);

        Task<User> UpdateAsync(User user);

        Task DeleteAsync(int id);
        Task<User?> GetByUserNamePasswordAsync(string userName, string password);

    }
}
