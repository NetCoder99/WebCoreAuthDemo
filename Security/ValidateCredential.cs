using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication1.Security
{
    public class ValidateCredential
    {
        public static ClaimsPrincipal Validate(Credential credential) {
            
            if (credential.UserName.Equals("admin") && credential.Password.Equals("password"))
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, credential.UserName),
                    new Claim(ClaimTypes.Email, credential.UserName + "@nowhere.com"),
                    new Claim("Department", "HR"),
                    new Claim("Admin", "Admin")
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                var claimsPrincipal = new ClaimsPrincipal(identity);
                return claimsPrincipal;
            }

            if (credential.UserName.Equals("hr") && credential.Password.Equals("password"))
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, credential.UserName),
                    new Claim(ClaimTypes.Email, credential.UserName + "@nowhere.com"),
                    new Claim("Department", "HR")
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                var claimsPrincipal = new ClaimsPrincipal(identity);
                return claimsPrincipal;
            }
            
            return null;

        }
    }
}
