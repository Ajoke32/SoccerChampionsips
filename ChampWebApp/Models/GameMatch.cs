using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChampWebApp.Models;

public class GameMatch
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public Command HomeCommand { get; set; }
    
    public Command VisitCommand { get; set; }
    
    public int HomeCommandId { get; set; }
    
    public int VisitCommandId { get; set; }
    
    public DateTime GameTime { get; set; }
    
    public List<MatchEvent> MatchEvents { get; set; }
    

}