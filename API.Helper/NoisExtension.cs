using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace API.Helper
{
    public static class NoisExtension
    {
        public static List<int> ToInts(this string input, char separator = ',')
        {
            return input.Split(separator).Select(v => { var x = 0; if (!int.TryParse(v, out x)) return null; return (int?)x; }).Where(v => v != null).Cast<int>().ToList();
        }

        public static Type GetCurrentType(this object obj)
        {
            var type = obj.GetType();
            if (type.BaseType != null && type.Namespace == "System.Data.Entity.DynamicProxies")
            {
                type = type.BaseType;
            }
            return type;
        }
        public static string GetValueOfClaim(this IPrincipal user, string claimName)
        {
            if (user.Identity.IsAuthenticated)
            {
                var claimsIdentity = user.Identity as ClaimsIdentity;
                if (claimsIdentity == null) return "";
                foreach (var claim in claimsIdentity.Claims)
                {
                    if (claim.Type == claimName)
                        return claim.Value;
                }
                return "";
            }
            else
                return "";
        }

        public static Dictionary<int, string> ToDictionary<TEnum>(this TEnum enumObj) where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum) throw new ArgumentException("An Enumeration type is required.", "enumObj");

            var result = new Dictionary<int, string>();

            foreach (var enumValue in Enum.GetValues(typeof(TEnum)))
            {
                result.Add(Convert.ToInt32(enumValue), enumValue.ToString());
            }
            return result;
        }
    }
}
