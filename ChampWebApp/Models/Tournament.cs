namespace ChampWebApp.Models;

public class Tournament 
{
    public string Name { get; set; }
    public List<StageGroup> Groups { get; set; }
}