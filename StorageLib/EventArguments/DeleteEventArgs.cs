using System;

namespace StorageLib.EventArguments
{
    public class DeleteEventArgs : EventArgs
    {
        public int id;

        public DeleteEventArgs(int id)
        {
            this.id = id;
        }
    }
}
