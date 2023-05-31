using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ChampWebApp.Models;

public class Player : SoccerPeople
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public decimal MarketPrice { get; set; }
    
    [Required]
    public string Foot { get; set; }
    
    [Required]
    public string Position { get; set; }
    
    [AllowNull]
    public int Height { get; set; }
    
    [AllowNull]
    public int Weight { get; set; }
    
    [Required]
    public int ClubNumber { get; set; }
}