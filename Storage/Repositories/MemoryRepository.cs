using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageLib.Interfaces;
using StorageLib.Entities;

namespace Storage.Repositories
{
    public class MemoryRepository : IRepository
    {
        private IGeneratorId generator;
        private List<User> users = new List<User>();

        public MemoryRepository(IGeneratorId generator)
        {
            this.generator = generator;
        }

        public int Add(User user)
        {
            if (user != null)
            {
                if (generator.MoveNext())
                {
                    user.Id = generator.Current;
                }

                users.Add(user);
                return user.Id;
            }

            return 0;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> Load()
        {
            throw new NotImplementedException();
        }

        public void Save(List<User> users)
        {
            throw new NotImplementedException();
        }

        public User SearchBy(IComparer<User> comparer, User searchingUser)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (comparer.Compare(users[i], searchingUser) == 0)
                {
                    return users[i];
                }
            }

            return null;
        }
    }
}
