using System.Collections.Generic;
using StorageLib.Entities;

namespace StorageLib.Interfaces
{
    public interface IRepository
    {
        void Save(List<User> users);
        List<User> Load();
    }
}
