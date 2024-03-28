using gamevault.Enums;

namespace gamevault.Models;

public class Game
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double AverageRating { get; set; }
    public Genres genres { get; set; }
    public int downloads { get; set; }
    
}

