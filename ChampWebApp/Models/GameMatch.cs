using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChampWebApp.Models;

public class GameMatch
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("HomeCommandId")] public Command HomeCommand { get; set; } = null!;

    [ForeignKey("VisitCommandId")] public Command VisitCommand { get; set; } = null!;
    
    public DateTime? GameTime { get; set; }

    [ForeignKey("TournamentId")] public Tournament Tournament { get; set; } = null!;
    

    public ICollection<MatchStatistic> MatchStatistics { get;}
    
    public ICollection<MatchEvent> MatchEvents { get; }

    public GameMatch()
    {
        MatchEvents = new List<MatchEvent>();
        MatchStatistics = new List<MatchStatistic>();
    }
}