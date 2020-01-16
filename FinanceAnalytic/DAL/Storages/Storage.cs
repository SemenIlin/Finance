using DAL.Interfaces;
using System.Collections.Generic;

namespace DAL.Storages
{
    public class Storage<T> where T : IMoneyOperation
    {
        private static Storage<T> storages;

        private Storage()
        {
            Storages = new List<T>();
        }

        public static Storage<T> GetStorages()
        {
            if (storages == null)
            {
                storages = new Storage<T>();
            }

            return storages;
        }

        public List<T> Storages { get; }
    }
}

