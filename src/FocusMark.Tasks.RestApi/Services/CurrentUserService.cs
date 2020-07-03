using FocusMark.Tasks.Application.Services;
using FocusMark.Tasks.Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FocusMark.Tasks.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor contextAccessor;

        public CurrentUserService(IHttpContextAccessor contextAccessor) => this.contextAccessor = contextAccessor;

        public string UserId => contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

        public string Username => contextAccessor.HttpContext?.User.FindFirstValue(FocusMarkClaimTypes.Username);

        public string Client => contextAccessor.HttpContext?.User.FindFirstValue(FocusMarkClaimTypes.ClientId);

        public string[] Permissions => contextAccessor.HttpContext?.User.FindFirstValue(FocusMarkClaimTypes.Scope).Split(' ');
    }
}
