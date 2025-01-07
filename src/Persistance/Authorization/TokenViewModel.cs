namespace Domain.Authorization
{
    public class TokenViewModel
    {
        public string Token { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string ExpirationTime { get; set; } = null!;
    }
}
