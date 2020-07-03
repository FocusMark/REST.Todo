namespace FocusMark.Tasks.Application.Services
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        string Username { get; }
        string[] Permissions { get; }
    }
}