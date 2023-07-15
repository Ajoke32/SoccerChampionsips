using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;


namespace ChampWebApp.Models;

public class Tournament
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    
    [JsonIgnore]
    public ICollection<StageGroup> StageGroups { get; }
    
    [JsonIgnore]
    public ICollection<LeagueSummary> LeagueSummaries { get; }

    public Tournament()
    {
        StageGroups = new List<StageGroup>();
        LeagueSummaries = new List<LeagueSummary>();
    }
}