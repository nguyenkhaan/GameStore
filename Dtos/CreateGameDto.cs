using System.ComponentModel.DataAnnotations;
namespace GameStore.Dtos;

public record CreateGameDto
{

    [Required][StringLength(50)] public string Name { get; set; } 
    [Required] [StringLength(20)] public string Genre { get; set; }
    [Required] [Range(1, 100)] public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; } 
}