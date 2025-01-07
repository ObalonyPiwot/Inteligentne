namespace MyProject.Persistance.Authorization
{
    public interface ICurrentUser
    {
        int Id { get; }
        string Name { get; }
        public Task SetCurrentUser(string token);
    }
}
