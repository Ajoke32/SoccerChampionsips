using System.ComponentModel.DataAnnotations;

namespace ChampWebApp.Models.Dtos;

public class UserRegisterDto
{
    public string Name { get; set; }
    
    [Required]
    [MinLength(7)]
    public string Password { get; set; }
    
    [Required]
    [MinLength(5)]
    [EmailAddress]
    public string Email { get; set; }
}