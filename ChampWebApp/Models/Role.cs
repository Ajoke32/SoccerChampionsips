using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChampWebApp.Models;

public class Role
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] public string Title { get; set; } = string.Empty;
    
    public int Code { get; set; }
    
    public ICollection<User> Users { get;}

    public Role()
    {
        Users = new List<User>();
    }
}