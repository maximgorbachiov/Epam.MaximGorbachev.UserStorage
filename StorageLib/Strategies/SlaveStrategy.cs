using System;
using System.Collections.Generic;
using StorageLib.Entities;
using FibonachyGenerator.Interfaces;

namespace StorageLib.Strategies
{
    public class SlaveStrategy : Strategy
    {
        public override int Add(User user, IGeneratorId generator)
        {
            throw new InvalidOperationException();
        }

        public override void Delete(int id)
        {
            throw new InvalidOperationException();
        }
    }
}
