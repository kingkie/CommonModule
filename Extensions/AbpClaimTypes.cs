using System.Security.Claims;

namespace Sharp.Infrastructure
{

    public static class SharpClaimTypes
    {
        public static string UserName { get; set; } = ClaimTypes.Name;

        public static string UserId { get; set; } = ClaimTypes.NameIdentifier;

        public static string Role { get; set; } = ClaimTypes.Role;

        
        public static string OrgId { get; set; } = "http://www.platformSharp.com/identity/claims/OrgId";
    }
}
