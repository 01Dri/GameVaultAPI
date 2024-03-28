using System.ComponentModel.DataAnnotations;
using gamevault.Enums;

namespace gamevault.Models;


public class Game
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(40)]
    public string Name { get; set; }
    [MaxLength(120)]
    public string Description { get; set; }
    [Required]
    public double AverageRating { get; set; }
    [Required]
    public Genres Genres { get; set; }
    [Required]
    [MinLength(0)]
    public int Downloads { get; set; }
    
}


