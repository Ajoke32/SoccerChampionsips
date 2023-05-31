using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ChampWebApp.Models;

public class Command
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public Country Country { get; set; }
    
    public int CountryId { get; set; }
    public int UEFARanking { get; set; }
    
    public List<Player> Players { get; set; }
    
    public string HomeStadium { get; set; }

    [AllowNull]
    public Coach Coach { get; set; }
    
    public int CoachId { get; set; }
    
    public StageGroup StageGroup { get; set; }
    
    public int StageGroupId { get; set; }
    
    public LeagueSummary LeagueSummary { get; set; }
    
    public int SummaryTableId { get; set; }

    public Command()
    {
        UEFARanking = 0;
    }
}