using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ChampWebApp.Models;

public class LeagueSummary
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public int? MatchesPlayed { get; set; }
    
    public int? Wins { get; set; }
    
    public int? Draws { get; set; }
    
    public int? Loses { get; set; }
    
    public int? GoalsFor { get; set; }

    public int? GoalsAgainst { get; set; }
    
    public int? GoalsDifference { get; set; }

    public LeagueSummary()
    {
        MatchesPlayed = 0;
        Wins = 0;
        Draws = 0;
        Loses = 0;
        GoalsFor = 0;
        GoalsAgainst = 0;
        GoalsDifference = 0;
    }
    
    [JsonIgnore]
    [ForeignKey("CommandId")] public Command Command { get; set; } = null!;
    
    [JsonIgnore]
    [ForeignKey("TournamentId")] public Tournament Tournament { get; set; } = null!;
}