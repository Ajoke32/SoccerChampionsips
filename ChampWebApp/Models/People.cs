using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChampWebApp.Models;

public class People
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string FirstName { get; set; }

    public string SecondName { get; set; }
    
    public string ImgLink { get; set; }

    public string FullName => $"{FirstName} {SecondName}";
    
    [ForeignKey("CountryId")]
    public Country Country { get; set; }
    
    private int _age;
    
    public int Age
    {
        get => _age;
        set
        {
            if (value > 0 && value < 110)
            {
                _age = value;
            }
        }
    }

    [Required]
    public DateTime DateOfBirth { get; set; }
    
    [ForeignKey("CommandId")]
    public Command? Command { get; set; }
    
    public People()
    {
        _age = (DateTime.Now - DateOfBirth).Days / 365;
    }
}