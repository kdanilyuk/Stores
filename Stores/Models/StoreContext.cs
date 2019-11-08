using Microsoft.EntityFrameworkCore;

namespace StoresChain.Models
{
    public class StoreContext : DbContext
    {
        public StoreContext() { }

        public StoreContext(DbContextOptions<StoreContext> options)
            :base(options)
        {
            Database.Migrate();
        }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=storedb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var baskinRobbins = new Store()
            {
                Name = "Baskin Robbins",
                Address = "MoMo",
                OpeningTime = "10:00",
                ClosingTime = "22:00",
                StoreId = 1
            };

            var mcDonalds = new Store()
            {
                Name = "McDonalds",
                Address = "Galileo",
                OpeningTime = "60:00",
                ClosingTime = "23:00",
                StoreId = 2
            };

            var bonGenie = new Store()
            {
                Name = "BonGenie",
                Address = "Prytytskogo 156",
                OpeningTime = "10:00",
                ClosingTime = "23:00",
                StoreId = 3
            };

            modelBuilder.Entity<Store>().HasData(
                baskinRobbins,
                mcDonalds,
                bonGenie
            );

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Name = "Chicken Burger",
                    Description = "Very very tasty",
                    ProductId = 1,
                    StoreId = mcDonalds.StoreId
                },
                new Product()
                {
                    Name = "Macaron",
                    Description = "Heavenly pleasure",
                    ProductId = 2,
                    StoreId = bonGenie.StoreId
                },
                new Product()
                {
                    Name = "IceCream BN",
                    Description = "So cold",
                    ProductId = 3,
                    StoreId = baskinRobbins.StoreId
                });
        }
    }
}
