using MyProject.Domain.Entities;
using MyProject.Persistance.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyProject.Persistance.Configurations
{
    public class CargoEntityConfiguration : BaseEntityConfiguration<CargoEntity>
    {
        private readonly static string _tableName = "Cargoes";

        public CargoEntityConfiguration() : base(_tableName) { }

        public override void Configure(EntityTypeBuilder<CargoEntity> builder)
        {
            base.Configure(builder);
        }
    }
}
