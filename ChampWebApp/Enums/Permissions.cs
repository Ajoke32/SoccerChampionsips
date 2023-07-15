namespace ChampWebApp.Enums;

[Flags]
public enum Permissions
{
    None =0,
    Create=1,
    Update=2,
    Delete=4,
    Read=8
}