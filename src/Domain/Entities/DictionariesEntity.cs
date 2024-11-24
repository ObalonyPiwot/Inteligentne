using MyProject.Domain.Common;

namespace MyProject.Domain.Entities
{
    
    public class ProductType : BaseAuditableEntity
    {
        public string Name { get; set; } = null!;
    }
    public class ProductGender : BaseAuditableEntity
    {
        public string Name { get; set; } = null!;
    } 
    public class ProductCategory : BaseAuditableEntity
    {
        public string Name { get; set; } = null!;
    }
    public class ProductSeason : BaseAuditableEntity
    {
        public string Name { get; set; } = null!;
    }
    public class ProductCondition : BaseAuditableEntity
    {
        public string Name { get; set; } = null!;
    }
    public class ProductMaterial : BaseAuditableEntity
    {
        public string Name { get; set; } = null!;
    }
    public class ProductColor : BaseAuditableEntity
    {
        public string Name { get; set; } = null!;
    }
    public class Brand : BaseAuditableEntity
    {
        public string Name { get; set; } = null!;
    }
}
