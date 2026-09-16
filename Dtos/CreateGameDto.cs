namespace GameStore.Dtos;

public record CreateGameDto
{
    public string Name { get; set; } 
    public string Genre { get; set; }
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; } 
}