using System.ComponentModel.DataAnnotations;

namespace gamevault.Models.Dto;

public record GameDTO(
    [Required(ErrorMessage = "The name field is required!")]
    string Name,
    [Required(ErrorMessage = "The description field is required!")]
    string Description,
    [Required(ErrorMessage = "The genre name field is required!")]
    string GenreName);

