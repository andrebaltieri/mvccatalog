using MvcCatalog.Data.Contexts;
using MvcCatalog.Domain;
using MvcCatalog.Domain.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MvcCatalog.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private MvcCatalogDataContext _context;

        public UserRepository(MvcCatalogDataContext context)
        {
            this._context = context;
        }

        public User Get(string username)
        {
            return _context.Users.Where(x => x.Username.ToLower() == username.ToLower()).FirstOrDefault();
        }

        public User Get(string username, string password)
        {
            return _context.Users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
        }

        public IList<User> Get()
        {
            return _context.Users.ToList();
        }

        public User Get(int id)
        {
            return _context.Users.Find(id);
        }

        public void SaveOrUpdate(User entity)
        {
            if (entity.Id == 0)
                _context.Users.Add(entity);
            else
                _context.Entry<User>(entity).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Users.Remove(_context.Users.Find(id));
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
