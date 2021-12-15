using API.Course.Business.Entities;
using API.Course.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Course.Infraestructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ClassesDbContext _context;

        public UserRepository(ClassesDbContext context)
        {
            _context = context; 
        }
        public void Add(User user)
        {
            _context.User.Add(user);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public User GetUser(string login)
        {
            return _context.User.FirstOrDefault(u => u.Login == login);
        }
    }
}
