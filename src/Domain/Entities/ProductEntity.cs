using MyProject.Domain.Common;
using MyProject.Domain.Entities;

namespace Domain.Entities
{
    public class ProductEntity : BaseAuditableEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int? ProductTypeId { get; set; }
        public ProductType? ProductType { get; set; }
        public int? ProductGenderId { get; set; }
        public ProductGender? ProductGender { get; set; }
        public int? ProductCategoryId { get; set; }
        public ProductCategory? ProductCategory { get; set; }
        public int? ProductSeasonId { get; set; }
        public ProductSeason? ProductSeason { get; set; }
        public int? ProductConditionId { get; set; }
        public ProductMaterial? ProductMaterial { get; set; }
        public int? ProductColorId { get; set; }
        public ProductColor? ProductColor { get; set; }
        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }
        public int LikeCount { get; set; }
        public bool Available { get; set; }
        public float Price { get; set; }
        public string Url { get; set; } = null!;
    }
}
