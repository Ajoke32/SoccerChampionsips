using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ChampWebApp.Models;

public class Command
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] 
    public string Name { get; set; } = string.Empty;

    public Country Country { get; set; } = null!;
    
    public int CountryId { get; set; }
    
    public int UefaRanking { get; set; }
    
    public string? HomeStadium { get; set; }

    public bool IsActiveCommand { get; set; } = true;
    
    public Coach? Coach { get; set; }
    public ICollection<Player> Players { get;}
    public ICollection<StageGroup> StageGroups { get; }
    public ICollection<LeagueSummary> LeagueSummaries { get;}
    public ICollection<MatchEvent> MatchEvents { get;}
    public ICollection<MatchStatistic> MatchStatistics { get;}

    public Command()
    {
        StageGroups = new List<StageGroup>();
        LeagueSummaries = new List<LeagueSummary>();
        MatchEvents = new List<MatchEvent>();
        MatchStatistics = new List<MatchStatistic>();
        Players = new List<Player>();
    }
}