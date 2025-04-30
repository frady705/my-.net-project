using faig.Core.Entities;
using faig.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace faig.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
       
            private readonly DbSet<User> _dbSet;

            public UserRepository(DataContext context)
            {
                _dbSet = context.Set<User>();
            }

            public IEnumerable<User> GetList()
            {
                return _dbSet.Include(u => u.Presence);
            }

            public async Task<List<User>> GetAllAsync()
            {
                return await _dbSet.ToListAsync();
            }

            public async Task<User?> GetByIdAsync(int id)
            {
                return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            }

            public async Task<User> AddAsync(User user)
            {
                await _dbSet.AddAsync(user);
                return user;
            }

            public async Task<User> UpdateAsync(User user)
            {
                var existingUser = await GetByIdAsync(user.Id);
                if (existingUser is null)
                {
                    throw new Exception("User not found");
                }

                existingUser.Name = user.Name;
                existingUser.Role = user.Role;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;

                return existingUser;
            }

            public async Task DeleteAsync(int id)
            {
                var existingUser = await GetByIdAsync(id);
                if (existingUser is not null)
                {
                    _dbSet.Remove(existingUser);
                }
            }

            public async Task<User?> GetByUserNamePasswordAsync(string userName, string password)
            {
                return await _dbSet
                   .Where(u => u.Name == userName && u.Password == password)
                   .FirstOrDefaultAsync();
            }
        }
    }
