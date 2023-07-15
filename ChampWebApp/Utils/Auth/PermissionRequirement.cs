using ChampWebApp.Enums;
using Microsoft.AspNetCore.Authorization;

namespace ChampWebApp.Utils.Auth;

public class PermissionRequirement : IAuthorizationRequirement
{
    public PermissionRequirement(Permissions permission)
    {
        Permissions = permission;
    }

    public Permissions Permissions { get; }
}