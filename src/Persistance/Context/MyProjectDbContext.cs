using MyProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Domain.Entities;

namespace MyProject.Persistance.Context
{
    public class MyProjectDbContext : DbContext, IMyProjectDbContext
    {

        public MyProjectDbContext(
            DbContextOptions<MyProjectDbContext> options) : base(options) 
        {
        }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductGender> Transactions { get; set; }
        public DbSet<ProductCategory> TransactionsProducts { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<ProductGender> ProductGender { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductSeason> ProductSeason { get; set; }
        public DbSet<ProductCondition> ProductCondition { get; set; }
        public DbSet<ProductMaterial> ProductMaterial { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CartEntity> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
