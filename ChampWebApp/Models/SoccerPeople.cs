namespace ChampWebApp.Models;

public abstract class SoccerPeople : People
{
    public Command Command { get; set; }
    
    public int CommandId { get; set; }
}