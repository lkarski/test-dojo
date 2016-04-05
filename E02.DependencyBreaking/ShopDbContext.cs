using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace E03.DependencyBreaking
{
    class ShopDbContext : IDisposable
    {
        public DbSet<ShoppingCart> ShoppingCarts{ get; set; }
        public DbSet<PromoGift> PromoGifts { get; set; }

        public ShopDbContext()
        {
            throw new ApplicationException("Could not connect to the database.");
        }

        public void Dispose()
        {
        }

        public class DbSet<TEntity> : List<TEntity>
        {
            public void Save(TEntity entity)
            {
                this.Add(entity);
            }
        }
    }
}
