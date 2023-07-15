using System.Security.Claims;
using ChampWebApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ChampWebApp.Utils;

public class ClaimsIdentityConfig
{
    private readonly List<Claim> _claims;

    public ClaimsIdentityConfig(User user)
    {
        _claims = new List<Claim>()
        {
            new Claim("Email",user.Email),
            new Claim("RoleId",user.RoleId.ToString()),
            new Claim("Name",user.Name),
            new Claim("Permissions",Convert.ToInt32(user.Permissions).ToString())
        };
    }
    public ClaimsPrincipal GetClaimsPrincipal()
    {
        return new ClaimsPrincipal(new ClaimsIdentity(_claims,
            CookieAuthenticationDefaults.AuthenticationScheme));
    }

    public void AddClaim(string title, string value)
    {
        _claims.Add(new Claim(title,value));
    }
}