using Microsoft.EntityFrameworkCore;
using StoresChain.Models;
using System.Collections.Generic;
using System.Linq;

namespace StoresChain.Services
{
    public class ProductRepository : IRepository<Product>
    {
        private StoreContext db;

        public ProductRepository(StoreContext context)
        {
            this.db = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products;
        }

        public IEnumerable<Product> GetByStoreId(int storeId)
        {
            return db.Products.Where(p => p.StoreId == storeId);
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public void Create(Product product)
        {
            db.Products.Add(product);
        }

        public void Update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Product product = db.Products.Find(id);
            if (product != null)
                db.Products.Remove(product);
        }
    }
}
