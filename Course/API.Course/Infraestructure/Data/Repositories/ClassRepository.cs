using API.Course.Business.Entities;
using API.Course.Business.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Course.Infraestructure.Data.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly ClassesDbContext _context;

        public ClassRepository(ClassesDbContext context)
        {
            _context = context;

        }
        public void Add(Class classe)
        {
            _context.Class.Add(classe);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IList<Class> GetByUserCode(int userCode)
        {
            return _context.Class.Include(i => i.User).Where(w => w.UserCode == userCode).ToList();
        }
    }
}
