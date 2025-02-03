using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Application.Features.Users
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }
    public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
    {
        public CurrentUser? GetCurrentUser()
        {
            var user = httpContextAccessor.HttpContext.User;

            if (user == null) throw new InvalidOperationException("User context is not present");

            if(user.Identity == null || !user.Identity.IsAuthenticated) return null;

            var userId = user.FindFirst(claim => claim.Type == ClaimTypes.NameIdentifier)!.Value;
            var roles = user.FindAll(claim => claim.Type == ClaimTypes.Role)!.Select(role => role.Value);

            return new CurrentUser(userId, roles);

        }
    }
}
