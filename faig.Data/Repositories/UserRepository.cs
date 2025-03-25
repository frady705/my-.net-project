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
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetList()
        {
            return _context.Users.Include(u => u.Presence);
        }
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User? GetById(int id)
        {
            return _context.Users.ToList().FirstOrDefault(x => x.Id == id);
        }

        public User Add(User user)
        {
            _context.Users.Add(user);
            return user;
        }

        public User Update(User user)
        {
            var existingUser = GetById(user.Id);
            if (existingUser is null)
            {
                throw new Exception("User not found");
            }

            existingUser.Name = user.Name;
            existingUser.Role = user.Role;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.UserName = user.UserName;
            return existingUser;
        }

        public void Delete(int id)
        {
            var existingUser = GetById(id);
            if (existingUser is not null)
            {
                _context.Users.Remove(existingUser);
            }
        }

      
    }
}
