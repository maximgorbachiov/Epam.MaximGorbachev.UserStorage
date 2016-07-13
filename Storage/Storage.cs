using System.Collections.Generic;
using StorageLib.Entities;
using StorageLib.Interfaces;

namespace StorageLib
{
    public class Storage
    {
        private IRepository repository;
        private IGeneratorId generator;
        private List<User> users = new List<User>();

        public int UsersCount { get; private set; }

        public Storage(IRepository repository, IGeneratorId generator)
        {
            this.repository = repository;
            this.generator = generator;
        }

        public int AddUser(User user)
        {
            if (user != null)
            {
                users.Add(user);
            }

            return 0;
        }

        public void DeleteUser(int id)
        {
            if (id > 0)
            {
               // repository.Delete(id);
            }
        }

        /*public User SearchBy(IComparer<User> comparator, User searchingUser)
        {
            
        }*/

        public void Save()
        {
            repository.Save(users);
        }

        public void Load()
        {
            users = repository.Load();
        }
    }
}
