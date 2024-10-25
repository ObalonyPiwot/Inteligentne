using System.Security.Claims;

namespace MyProject.Domain.Authorization
{
    public interface ICurrentUser
    {
        string Email { get; }
        string Id { get; }
        string FullName { get; }

        Roles? Roles { get; }
        List<Permission> Permissions { get; }

        bool HasPermision(Permission permissions);
        void SetCurrentUser(IEnumerable<Claim> claims);

    }
}
