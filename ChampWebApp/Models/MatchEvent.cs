using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ChampWebApp.Models;

public enum Event 
{
    Goal,
    RedCard,
    YellowCard,
    Kick,
    KickToGoal,
    Penalty,
    Violation,
    Corner
}

public class MatchEvent
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [AllowNull]
    [Column(TypeName = "int")]
    public Event Event { get; set; }

    public Player Player { get; set; }
    
    public int PlayerId { get; set; }
    
    public GameMatch GameMatch { get; set; }
    
    public int MatchId { get; set; }
    
}