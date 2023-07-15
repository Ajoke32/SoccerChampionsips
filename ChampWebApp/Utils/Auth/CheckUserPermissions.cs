using ChampWebApp.Enums;

namespace ChampWebApp.Utils.Auth;

public static class CheckUserPermissions
{
    public static bool HaveAccess(Permissions userPermissions,Permissions compare)
    {
        var intPermission = Convert.ToInt32(userPermissions);
        var intRequirement = Convert.ToInt32(compare);
        
        if ((intPermission & intRequirement) == intRequirement)
        {
            return true;
        }

        return false;
    }
}