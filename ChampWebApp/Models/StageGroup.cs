using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChampWebApp.Models;

public class StageGroup
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string? Name { get; set; }

    [ForeignKey("CommandId")]
    public Command Command { get; set; } = null!;

    [ForeignKey("TournamentId")]
    public Tournament Tournament { get; set; } = null!;
}