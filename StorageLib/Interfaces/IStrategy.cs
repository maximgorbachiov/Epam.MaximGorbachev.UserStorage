using System.Collections.Generic;
using StorageLib.Entities;
using FibonachyGenerator.Interfaces;

namespace StorageLib.Interfaces
{
    public interface IStrategy
    {
        List<User> Users { get; }

        int Add(User user, IGeneratorId generator);
        void Delete(int id);
        List<User> SearchBy(IComparer<User> comparer, User searchingUser);
    }
}
