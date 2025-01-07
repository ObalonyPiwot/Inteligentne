using Microsoft.AspNetCore.Http;
using MyProject.Persistance.Authorization;

namespace MyProject.Persistance.Middlewares
{
    public class CurrentUserMiddleware
    {
        private readonly RequestDelegate _next;

        public CurrentUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ICurrentUser currentUser)
        {
            // Pobierz nagłówek Authorization
            var authorizationHeader = context.Request.Headers["Authorization"].ToString();

            if (!string.IsNullOrWhiteSpace(authorizationHeader) && authorizationHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                // Wyciągnij token Bearer
                var bearerToken = authorizationHeader.Substring("Bearer ".Length).Trim();

                // Ustaw użytkownika w currentUser
                await currentUser.SetCurrentUser(bearerToken);
            }

            // Przekaż dalej do następnego middleware
            await _next.Invoke(context);
        }
    }
}
