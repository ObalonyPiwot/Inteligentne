using MyProject.Domain.Common;

namespace Domain.Entities
{
    public class UserEntity: BaseEntity
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string? Token { get; set; }
    }
}
