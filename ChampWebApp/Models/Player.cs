using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChampWebApp.Models;

public class Player : People
{

    [Required]
    [Precision(15,2)]
    public decimal MarketPrice { get; set; }

    [Required] public string Foot { get; set; } = string.Empty;

    [Required] public string Position { get; set; } = string.Empty;
    
    public int? Height { get; set; }
    

    public int? Weight { get; set; }
    
    [Required]
    public int ClubNumber { get; set; }

    public List<MatchEvent> MatchEvents { get; } = new();
}