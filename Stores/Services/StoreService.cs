using StoresChain.Models;
using StoresChain.Services;
using System;

namespace Stores.Services
{
    public class StoreService : IDisposable
    {
        private StoreContext db = new StoreContext();
        private ProductRepository productRepository;
        private StoreRepository storeRepository;

        public ProductRepository Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }

        public StoreRepository Stores
        {
            get
            {
                if (storeRepository == null)
                    storeRepository = new StoreRepository(db);
                return storeRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
