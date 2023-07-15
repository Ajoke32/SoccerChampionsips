using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChampWebApp.Models;

public class MatchStatistic
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("GameMatchId")] public GameMatch GameMatch { get; set; } = null!;

    [ForeignKey("CommandId")] public Command Command { get; set; } = null!;

    public int? Goals { get; set; }

    public int? RedCards { get; set; }
    
    public int? YellowCards { get; set; }
    
    public int? Kicks { get; set; }
    
    public int? KicksToGoal { get; set; }
    
    public int? Penalties { get; set; }
    
    public int? Violations { get; set; }
    
    public int? Corners { get; set; }
    
}