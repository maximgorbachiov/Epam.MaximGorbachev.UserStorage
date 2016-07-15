using System.Collections.Generic;
using StorageLib.Entities;

namespace UserStorageConsole
{
    public class UserComparator : IComparer<User>
    {
        public int Compare(User x, User y)
        {
            return (x.Gender == y.Gender) ? 0 : 1;
        }
    }
}
