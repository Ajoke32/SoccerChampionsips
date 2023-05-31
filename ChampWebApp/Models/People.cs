namespace ChampWebApp.Models;

public abstract class People
{
    public string FirstName { get; set; }

    public string SecondName { get; set; }
    
    public string ImgLink { get; set; }

    public string FullName => $"{FirstName} {SecondName}";
    
    public Country Country { get; set; }
    
    public int CountryId { get; set; }
    
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

    public DateTime DateOfBirth { get; set; }
    
    
    public People()
    {
        _age = (DateTime.Now - DateOfBirth).Days / 365;
    }
}