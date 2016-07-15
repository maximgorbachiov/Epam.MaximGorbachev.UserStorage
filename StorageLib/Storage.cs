using System;
using System.Collections.Generic;
using StorageLib.Entities;
using StorageLib.Interfaces;
using StorageLib.EventArguments;
using FibonachyGenerator.Interfaces;

namespace StorageLib
{
    public class Storage : IStorage
    {
        private IRepository repository;
        private IStrategy strategy;
        private IGeneratorId generator;

        public event EventHandler<AddEventArgs> OnAddUser = delegate { };
        public event EventHandler<DeleteEventArgs> OnDeleteUser = delegate { };

        public int UsersCount { get; private set; }

        public Storage(IRepository repository, IStrategy strategy, IGeneratorId generator)
        {
            this.repository = repository;
            this.strategy = strategy;
            this.generator = generator;
        }

        public int AddUser(User user)
        {
            int id = strategy.Add(user, generator);
            //OnAddUserEvent(new AddEventArgs(user));

            return id;
        }

        public void DeleteUser(int id)
        {
            strategy.Delete(id);
            //OnDeleteUserEvent(new DeleteEventArgs(id));
        }

        public List<User> SearchBy(IComparer<User> comparator, User searchingUser)
        {
            return strategy.SearchBy(comparator, searchingUser);
        }

        /*public void Save()
        {
            ServiceState state = new ServiceState() { Users = strategy.Users, LastId = generator.Current };
            
            repository.Save(state);
        }

        public void Load()
        {
            ServiceState state = repository.Load();
            users = state.Users;

            while(generator.Current < state.LastId)
            {
                generator.MoveNext();
            }
        }*/

        /*protected virtual void OnAddUserEvent(AddEventArgs e)
        {
            if (OnAddUser != null)
            {
                OnAddUser(this, e);
            }
        }

        protected virtual void OnDeleteUserEvent(DeleteEventArgs e)
        {
            if (OnDeleteUser != null)
            {
                OnDeleteUser(this, e);
            }
        }*/
    }
}
