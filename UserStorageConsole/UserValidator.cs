using StorageLib.Entities;
using StorageLib.Interfaces;

namespace UserStorageConsole
{
    public class UserValidator : IValidator
    {
        public bool Validate(User user)
        {
            return (user.Gender == Gender.Man || user.Gender == Gender.Woman);
        }
    }
}
