using MyProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CartEntity : BaseAuditableEntity
    {
        public string ProductIds { get; set; } = null!;
        public int UserId { get; set; }
        public UserEntity? User { get; set; }
    }
}
