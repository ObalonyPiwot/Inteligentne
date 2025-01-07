using Microsoft.EntityFrameworkCore;
using MyProject.Persistance.Context;

namespace MyProject.Persistance.Authorization
{
    public class CurrentUserService : ICurrentUser
    {
        private int _id;
        private string _name;

        private readonly IMyProjectDbContext DbContext;
        public CurrentUserService(IMyProjectDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public int Id => GetId();
        public string Name => GetName();

        private int GetId()
        {
            return _id;
        }
        private string GetName()
        {
            if (_name == null)
            {
                throw new ArgumentNullException("Current user name is null or empty!");
            }

            return _name;
        }

        public async Task SetCurrentUser(string token)
        {
            var user =await  DbContext.Users.FirstOrDefaultAsync(x=>x.Token == token);
            if (user == null)
            {
                throw new ArgumentNullException("Current user is null or empty!");
            }
            _id = user.Id;
            _name = user.UserName;
        }
    }
}
