using System.ComponentModel.DataAnnotations;
using gamevault.Enums;

namespace gamevault.Models;


public class Game
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double AverageRating { get; set; }
    public Genres Genres { get; set; }
    public int Downloads { get; set; }

    public Game(int? id, string name, string description, double averageRating, Genres genres, int downloads)
    {
        Id = id;
        Name = name;
        Description = description;
        AverageRating = averageRating;
        Genres = genres;
        Downloads = downloads;
    }
}


