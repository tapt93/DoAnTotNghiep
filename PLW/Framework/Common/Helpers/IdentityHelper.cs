using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;
using System.Security.Principal;
using System.Linq;

namespace Framework.Common.Helpers
{
    public static class IdentityHelper
    {
        public static string GetUserAccount(this IIdentity identity)
        {
            if (identity == null) return string.Empty;

            var auth = (ClaimsIdentity)identity;
            var claim = auth.Claims.SingleOrDefault(c => c.Type == "sub");

            return claim.Value;
        }
    }
}
