using Microsoft.EntityFrameworkCore;
using StoresChain.Models;
using System.Collections.Generic;
using System.Linq;

namespace StoresChain.Services
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
    public class StoreRepository : IRepository<Store>
    {
        private StoreContext db;

        public StoreRepository(StoreContext context)
        {
            this.db = context;
        }

        public IEnumerable<Store> GetAll()
        {
            return db.Stores.ToList();
        }

        public Store Get(int id)
        {
            return db.Stores.Find(id);
        }

        public void Create(Store store)
        {
            db.Stores.Add(store);
        }

        public void Update(Store store)
        {
            db.Entry(store).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Store store = db.Stores.Find(id);
            if (store != null)
                db.Stores.Remove(store);
        }
    }
}
