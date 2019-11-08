using System.Security.Claims;

namespace Identity.Services.Identity
{
    public interface IDynamicPermissionService
    {
        bool CanAccess(ClaimsPrincipal user, string area, string controller, string action);
    }
}   