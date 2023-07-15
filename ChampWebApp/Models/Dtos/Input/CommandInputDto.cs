using System.ComponentModel.DataAnnotations;

namespace ChampWebApp.Models.Dtos.Input;

public class CommandInputDto
{
    [Required]
    [MinLength(4)]
    public string Name { get; set; } = string.Empty;

    public int CountryId { get; set; }

    public int UefaRanking { get; set; } = 0;
    
    public string? HomeStadium { get; set; }

    public bool IsActiveCommand { get; set; } = true;
    
    public int? CoachId { get; set; }
}