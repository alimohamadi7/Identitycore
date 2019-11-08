using System.Security.Claims;

namespace Identity.Services.Identity
{
    public class DynamicPermissionService : IDynamicPermissionService
    {
        public bool CanAccess(ClaimsPrincipal user, string area, string controller, string action)
        {
            var key = $"{area}:{controller}:{action}";

            return user.HasClaim(ConstantPolicies.DynamicPermission, key);
        }
    }
}