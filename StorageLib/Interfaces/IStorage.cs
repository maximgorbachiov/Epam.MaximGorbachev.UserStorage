using System.Collections.Generic;
using StorageLib.Entities;

namespace StorageLib.Interfaces
{
    public interface IStorage
    {
        int AddUser(User user);
        void DeleteUser(int id);
        List<User> SearchBy(IComparer<User> comparator, User searchingUser);
    }
}
