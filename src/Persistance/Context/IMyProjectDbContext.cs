using MyProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Domain.Entities;

namespace MyProject.Persistance.Context
{
    public interface IMyProjectDbContext
    {
        #region Tables
        public DbSet<ProductEntity> Products { get; }
        public DbSet<ProductGender> Transactions { get; }
        public DbSet<ProductCategory> TransactionsProducts { get; }
        public DbSet<ProductType> ProductType { get; }
        public DbSet<ProductGender> ProductGender { get; }
        public DbSet<ProductCategory> ProductCategory { get; }
        public DbSet<ProductSeason> ProductSeason { get; }
        public DbSet<ProductCondition> ProductCondition { get; }
        public DbSet<ProductMaterial> ProductMaterial { get; }
        public DbSet<UserEntity> Users { get; }
        public DbSet<CartEntity> Carts { get; }

        #endregion Tables

        #region Views



        #endregion Views

        DatabaseFacade Database { get; }

        EntityEntry Entry(object entity);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
