using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using ChampWebApp.Enums;


namespace ChampWebApp.Models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    public string PasswordHash { get; set; }
    
    public string PasswordSalt { get; set; }
    
    public int RoleId { get; set; }
    
    public Permissions Permissions { get; set; }
    
    public Role Role { get; set; }

    public User()
    {
        RoleId = 1;
    }
}