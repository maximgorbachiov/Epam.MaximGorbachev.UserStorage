using System;
using System.Collections.Generic;
using StorageLib.Entities;
using StorageLib.Interfaces;
using FibonachyGenerator.Interfaces;

namespace StorageLib.Strategies
{
    public class MasterStrategy : Strategy
    {
        private IValidator validator;

        public MasterStrategy(IValidator validator)
        {
            this.validator = validator;
        }

        public override int Add(User user, IGeneratorId generator)
        {
            if (user == null)
            {
                throw new NullReferenceException(nameof(user));
            }

            if (!validator.Validate(user))
            {
                throw new ArgumentException(nameof(user));
            }

            if (!generator.MoveNext())
            {
                return 0;
            }

            user.Id = generator.Current;
            users.Add(user);

            return user.Id;
        }

        public override void Delete(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            users.Remove(users.Find(user => user.Id == id));
        }
    }
}
