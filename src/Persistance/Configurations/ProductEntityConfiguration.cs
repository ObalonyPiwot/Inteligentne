using MyProject.Persistance.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace MyProject.Persistance.Configurations
{
    public class ProductEntityConfiguration : BaseEntityConfiguration<ProductEntity>
    {
        private readonly static string _tableName = "Productes";

        public ProductEntityConfiguration() : base(_tableName) { }

        public override void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            base.Configure(builder);
        }
    }
}
