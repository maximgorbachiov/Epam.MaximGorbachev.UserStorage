using System;
using System.Collections.Generic;
using StorageLib.Entities;
using StorageLib.Interfaces;
using FibonachyGenerator.Interfaces;

namespace StorageLib.Strategies
{
    public abstract class Strategy : IStrategy
    {
        protected List<User> users = new List<User>();

        public List<User> Users
        {
            get
            {
                List<User> newUsers = new List<User>();

                foreach (var user in users)
                {
                    newUsers.Add((User)user.Clone());
                }

                return newUsers;
            }
        }

        public abstract int Add(User user, IGeneratorId generator);
        public abstract void Delete(int id);

        public virtual List<User> SearchBy(IComparer<User> comparer, User searchingUser)
        {
            if (comparer == null)
            {
                throw new NullReferenceException(nameof(comparer));
            }

            if (searchingUser == null)
            {
                throw new NullReferenceException(nameof(searchingUser));
            }

            List<User> resultUsers = new List<User>();

            foreach(var user in users)
            {
                if (comparer.Compare(user, searchingUser) == 0)
                {
                    resultUsers.Add(user);
                }
            }

            return resultUsers;
        }
    }
}
