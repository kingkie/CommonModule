using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace Sharp.Infrastructure
{
    public static class ClaimsIdentityExtensions
    {
        /// <summary>
        /// 获取用户Id
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static int GetUserId(this IIdentity identity)
        {
            var claimsIdentity = identity as ClaimsIdentity;

            var userIdOrNull = claimsIdentity?.Claims?.FirstOrDefault(c => c.Type == SharpClaimTypes.UserId);
            if (userIdOrNull == null || userIdOrNull.Value.IsNullOrEmpty())
            {
                return 0;
            }

            return Convert.ToInt32(userIdOrNull.Value);
        }

        /// <summary>
        /// 获取OrgId
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static Guid? GetOrgId(this IIdentity identity)
        {
            var claimsIdentity = identity as ClaimsIdentity;

            var userIdOrNull = claimsIdentity?.Claims?.FirstOrDefault(c => c.Type == SharpClaimTypes.OrgId);
            if (userIdOrNull == null || userIdOrNull.Value.IsNullOrEmpty())
            {
                return Guid.Empty;
            }

            return Guid.Parse(userIdOrNull.Value);
        }
        /// <summary>
        /// 获取用户名
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string GetUserName(this IIdentity identity)
        {
            var claimsIdentity = identity as ClaimsIdentity;

            var userIdOrNull = claimsIdentity?.Claims?.FirstOrDefault(c => c.Type == SharpClaimTypes.UserName);
            if (userIdOrNull == null || userIdOrNull.Value.IsNullOrEmpty())
            {
                return string.Empty;
            }

            return userIdOrNull.Value;
        }


    }
}