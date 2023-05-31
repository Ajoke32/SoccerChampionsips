using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChampWebApp.Models;

public class StageGroup
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Name { get; set; } 
    
    public List<Command> Commands { get; set; }

    public Tournament Tournament { get; set; }

    public int? ChampionshipId { get; set; }
    
}