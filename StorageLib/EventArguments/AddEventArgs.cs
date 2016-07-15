using System;
using StorageLib.Entities;

namespace StorageLib.EventArguments
{
    public class AddEventArgs : EventArgs
    {
        public User user;

        public AddEventArgs(User user)
        {
            this.user = user;
        }
    }
}
