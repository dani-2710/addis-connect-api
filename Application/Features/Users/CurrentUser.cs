namespace Application.Features.Users
{
    public record CurrentUser(string Id, IEnumerable<string> Roles);
}
