﻿using System;

namespace StorageLib.Entities
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public CountryVisa[] Visas { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() == typeof(User))
            {
                User user = (User)obj;
                return (Id == user.Id);
            }

            return false;
        }


        public override int GetHashCode()
        {
            return 0;
        }


        public override string ToString()
        {
            return Name + " " + SecondName + " " + DateOfBirth + " " + Gender + " " + Id;
        }

    }
}
