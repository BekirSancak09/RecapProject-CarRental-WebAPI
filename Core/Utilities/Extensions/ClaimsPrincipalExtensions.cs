using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Extensions
{
  public static class ClaimsPrincipalExtensions
    {
        /// <summary>
        /// Claim'leri getirir...
        /// </summary>
        /// <param name="claimsPrincipal"></param>
        /// <param name="claimType"></param>
        /// <returns></returns>
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;

        }
        /// <summary>
        /// Rolleri getirir...
        /// </summary>
        /// <param name="claimsPrincipal"></param>
        /// <returns></returns>
        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
