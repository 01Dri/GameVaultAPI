namespace gamevault.Models.Dto;

public record GameResponseDTO(int? Id, string Name, string Description, double AverageRating, string GenreName, int Downloads)
{
    
}