using System.ComponentModel;

namespace MyProject.Domain.Authorization
{
    public enum Roles
    {

        [Description("Superuser")]
        Superuser,

        [Description("None")]
        None
    }
}
