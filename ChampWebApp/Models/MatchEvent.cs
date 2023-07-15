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
    
    [Column(TypeName = "int")]
    public Event Event { get; set; }

    [ForeignKey("PlayerId")]
    public Player? Player { get; set; }

    [ForeignKey("CommandId")] public Command Command { get; set; } = null!;

    [ForeignKey("GameMatchId")] public GameMatch GameMatch { get; set; } = null!;

}