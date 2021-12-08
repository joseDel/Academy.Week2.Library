using Library.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Week2.Library.Entities;
using Academy.Week2.Library.Repos;

namespace Library.Mock.Repos
{
    public class MockUsersRepository : IUsersRepository
    {
        public bool Add(User user)
        {
            if (user == null)
                return false;

            user.Id = InMemoryStorage.users.Max(b => b.Id) + 1;
            InMemoryStorage.users.Add(user);
            return true;
        }

        public bool Delete(User item)
        {
            throw new NotImplementedException();
        }

        public List<User> FetchAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> FetchAllFilter(Func<User, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public User? GetByEmail(string email)
        {
            return InMemoryStorage.users.SingleOrDefault(u => u.Email == email);
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
