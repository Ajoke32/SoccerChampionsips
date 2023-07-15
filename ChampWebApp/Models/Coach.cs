using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChampWebApp.Models;

public class Coach : People
{
    public int Rank { get; set; }
}