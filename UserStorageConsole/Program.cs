using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using StorageLib.Entities;
using StorageLib.Interfaces;
using StorageLib.Repositories;
using StorageLib.Strategies;
using FibonachyGenerator;
using FibonachyGenerator.Interfaces;
using FibonachyGenerator.Generators;

namespace UserStorageConsole
{
    class Program
    {
        public const string FILENAME = "fileName";

        static void Main(string[] args)
        {
            int[] idArray = new int[3];
            string fileName = ConfigurationManager.AppSettings[FILENAME];

            IValidator validator = new UserValidator();
            IStrategy masterStrategy = new MasterStrategy(validator);
            IStrategy slaveStrategy = new SlaveStrategy();

            IRepository xmlRepository = new XMLRepository(fileName);
            IGeneratorId generator = new IdGenerator();

            IStorage masterStorage = new StorageLib.Storage(xmlRepository, masterStrategy, generator);
            IStorage slaveStorage = new StorageLib.Storage(xmlRepository, slaveStrategy, generator);

            idArray[0] = masterStorage.AddUser(new User { Name = "Maxim", Gender = Gender.Man });
            idArray[1] = masterStorage.AddUser(new User { Name = "Olya", Gender = Gender.Woman });
            idArray[2] = masterStorage.AddUser(new User { Name = "Natasha", Gender = Gender.Woman });
            ((StorageLib.Storage)masterStorage).Save();
            ((StorageLib.Storage)masterStorage).Load();

            IComparer<User> comparer = new UserComparator();
            List<User> men = masterStorage.SearchBy(comparer, new User { Gender = Gender.Man });

            for (int i = 0; i < men.Count; i++)
            {
                Console.WriteLine(men[i].Name + "'s gender is -> " + men[i].Gender);
            }

            List<User> women = masterStorage.SearchBy(comparer, new User { Gender = Gender.Woman });

            for (int i = 0; i < women.Count; i++)
            {
                Console.WriteLine(women[i].Name + "'s gender is -> " + women[i].Gender);
            }

            Console.ReadKey();
        }
    }
}
